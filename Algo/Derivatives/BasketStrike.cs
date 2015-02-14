namespace StockSharp.Algo.Derivatives
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Ecng.ComponentModel;

	using StockSharp.BusinessEntities;
	using StockSharp.Messages;

	/// <summary>
	/// ����������� ������, ��������� �� ���������� ������ ��������.
	/// </summary>
	public abstract class BasketStrike : BasketSecurity
	{
		/// <summary>
		/// ���������������� <see cref="BasketStrike"/>.
		/// </summary>
		/// <param name="underlyingAsset">������� �����.</param>
		/// <param name="securityProvider">��������� ���������� �� ������������.</param>
		/// <param name="dataProvider">��������� ������-������.</param>
		protected BasketStrike(Security underlyingAsset, ISecurityProvider securityProvider, IMarketDataProvider dataProvider)
		{
			if (underlyingAsset == null)
				throw new ArgumentNullException("underlyingAsset");

			if (securityProvider == null)
				throw new ArgumentNullException("securityProvider");

			if (dataProvider == null)
				throw new ArgumentNullException("dataProvider");

			UnderlyingAsset = underlyingAsset;
			SecurityProvider = securityProvider;
			DataProvider = dataProvider;
		}

		/// <summary>
		/// ��������� ���������� �� ������������.
		/// </summary>
		public ISecurityProvider SecurityProvider { get; private set; }

		/// <summary>
		/// ��������� ������-������.
		/// </summary>
		public virtual IMarketDataProvider DataProvider { get; private set; }

		/// <summary>
		/// ������� �����.
		/// </summary>
		public Security UnderlyingAsset { get; private set; }

		/// <summary>
		/// �����������, �� ������� ������� ������ �������.
		/// </summary>
		public override IEnumerable<Security> InnerSecurities
		{
			get
			{
				var derivatives = UnderlyingAsset.GetDerivatives(SecurityProvider, ExpiryDate);

				var type = OptionType;

				if (type != null)
					derivatives = derivatives.Filter((OptionTypes)type);

				return FilterStrikes(derivatives);
			}
		}

		/// <summary>
		/// �������� ��������������� �������.
		/// </summary>
		/// <param name="allStrikes">��� �������.</param>
		/// <returns>��������������� �������.</returns>
		protected abstract IEnumerable<Security> FilterStrikes(IEnumerable<Security> allStrikes);
	}

	/// <summary>
	/// ����������� ������, ���������� � ���� ������� �������� ������� ������.
	/// </summary>
	public class OffsetBasketStrike : BasketStrike
	{
		private readonly Range<int> _strikeOffset;
		private decimal _strikeStep;

		/// <summary>
		/// ������� <see cref="OffsetBasketStrike"/>.
		/// </summary>
		/// <param name="underlyingSecurity">������� �����.</param>
		/// <param name="securityProvider">��������� ���������� �� ������������.</param>
		/// <param name="dataProvider">��������� ������-������.</param>
		/// <param name="strikeOffset">������� ������ �� ������������ ������� (������������� �������� ������ ����� � ������� � �������, ������������� - ��� �����).</param>
		public OffsetBasketStrike(Security underlyingSecurity, ISecurityProvider securityProvider, IMarketDataProvider dataProvider, Range<int> strikeOffset)
			: base(underlyingSecurity, securityProvider, dataProvider)
		{
			if (strikeOffset == null)
				throw new ArgumentNullException("strikeOffset");

			_strikeOffset = strikeOffset;
		}

		/// <summary>
		/// �������� ��������������� �������.
		/// </summary>
		/// <param name="allStrikes">��� �������.</param>
		/// <returns>��������������� �������.</returns>
		protected override IEnumerable<Security> FilterStrikes(IEnumerable<Security> allStrikes)
		{
			if (_strikeStep == 0)
				_strikeStep = UnderlyingAsset.GetStrikeStep(SecurityProvider, ExpiryDate);

			var centralStrike = UnderlyingAsset.GetCentralStrike(DataProvider, allStrikes);

			var callStrikeFrom = centralStrike.Strike + _strikeOffset.Min * _strikeStep;
			var callStrikeTo = centralStrike.Strike + _strikeOffset.Max * _strikeStep;

			var putStrikeFrom = centralStrike.Strike - _strikeOffset.Max * _strikeStep;
			var putStrikeTo = centralStrike.Strike - _strikeOffset.Min * _strikeStep;

			return allStrikes.Where(s =>
							(s.OptionType == OptionTypes.Call && s.Strike >= callStrikeFrom && s.Strike <= callStrikeTo)
							||
							(s.OptionType == OptionTypes.Put && s.Strike >= putStrikeFrom && s.Strike <= putStrikeTo)
						)
						.OrderBy(s => s.Strike);
		}
	}

	/// <summary>
	/// ����������� ������, ���������� � ���� ������� �������� ������� �������������.
	/// </summary>
	public class VolatilityBasketStrike : BasketStrike
	{
		private readonly Range<decimal> _volatilityRange;

		/// <summary>
		/// ������� <see cref="VolatilityBasketStrike"/>.
		/// </summary>
		/// <param name="underlyingAsset">������� �����.</param>
		/// <param name="securityProvider">��������� ���������� �� ������������.</param>
		/// <param name="dataProvider">��������� ������-������.</param>
		/// <param name="volatilityRange">������� �������������.</param>
		public VolatilityBasketStrike(Security underlyingAsset, ISecurityProvider securityProvider, IMarketDataProvider dataProvider, Range<decimal> volatilityRange)
			: base(underlyingAsset, securityProvider, dataProvider)
		{
			if (volatilityRange == null)
				throw new ArgumentNullException("volatilityRange");

			_volatilityRange = volatilityRange;
		}

		/// <summary>
		/// �������� ��������������� �������.
		/// </summary>
		/// <param name="allStrikes">��� �������.</param>
		/// <returns>��������������� �������.</returns>
		protected override IEnumerable<Security> FilterStrikes(IEnumerable<Security> allStrikes)
		{
			return allStrikes.Where(s =>
			{
				var iv = (decimal?)DataProvider.GetSecurityValue(s, Level1Fields.ImpliedVolatility);
				return iv != null && _volatilityRange.Contains(iv.Value);
			});
		}
	}
}