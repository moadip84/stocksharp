namespace StockSharp.Algo.Indicators
{
	using System;
	using System.Collections.Generic;

	using Ecng.Common;

	/// <summary>
	/// <para>����� ������������ ��� ������������� ���������� � ������ � ����������, ������������ ������ ��� ����.</para>
	/// <para>����� ��������� <see cref="IEquatable{T}"/>, ������� ��������� ������ � ������� ���������� ��������, ��� ����
	/// ����� �� ���������, �� �� ����������� ��������� �������� �� �� ��������.</para>
	/// </summary>
	public class IndicatorToken : Equatable<IndicatorToken>
	{
		/// <summary>
		/// ���������.
		/// </summary>
		public IIndicator Indicator { get; private set; }

		/// <summary>
		/// �������� ������ ��� ����������.
		/// </summary>
		public IIndicatorSource Source { get; private set; }

		/// <summary>
		/// ���������, �������� ������ �����������.
		/// </summary>
		public IIndicatorContainer Container { get; internal set; }

		/// <summary>
		/// �������� ��� �������� ����������.
		/// </summary>
		/// <returns>��� �������� ����������. ������ ���������, ���� �������� ���.</returns>
		public IEnumerable<Tuple<IIndicatorValue, IIndicatorValue>> Values
		{
			get { return Container.GetValues(this); }
		}

		/// <summary>
		/// ������� <see cref="IndicatorToken"/>.
		/// </summary>
		/// <param name="indicator">���������.</param>
		/// <param name="source">�������� ������ ��� ����������.</param>
		public IndicatorToken(IIndicator indicator, IIndicatorSource source)
		{
			if (indicator == null)
				throw new ArgumentNullException("indicator");

			if (source == null)
				throw new ArgumentNullException("source");

			Indicator = indicator;
			Source = source;
		}

		/// <summary>
		/// �������� �������� ���������� �� �������.
		/// </summary>
		/// <param name="index">���������� ����� �������� � �����.</param>
		/// <returns>��������� ��������. ���� �������� �� ����������, �� ����� ���������� null.</returns>
		public virtual Tuple<IIndicatorValue, IIndicatorValue> GetValue(int index)
		{
			return Container.GetValue(this, index);
		}

		/// <summary>
		/// ���������� ��� ������.
		/// </summary>
		/// <returns>��� ������.</returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return (Indicator.GetHashCode() * 397) ^ (Source.GetHashCode());
			}
		}

		/// <summary>
		/// ��������� ����� �� ��������� ����������� � <paramref name="other"/>.
		/// </summary>
		/// <param name="other">����� ��� ���������.</param>
		/// <returns>true, ���� ������ �����.</returns>
		protected override bool OnEquals(IndicatorToken other)
		{
			return Source.Equals(other.Source) && Indicator.Equals(other.Indicator);
		}

		/// <summary>
		/// ������� ����� ������� ������. ����� ����� ����� ��������� �� ��� �� ����� ��������� � ��������.
		/// </summary>
		/// <returns>����� ������.</returns>
		public override IndicatorToken Clone()
		{
			return new IndicatorToken(Indicator, Source);
		}
	}
}