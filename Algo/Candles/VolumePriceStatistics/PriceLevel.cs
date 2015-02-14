namespace StockSharp.Algo.Candles.VolumePriceStatistics
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using StockSharp.Algo.Candles.Compression;
	using StockSharp.Messages;

	/// <summary>
	/// ������� �������.
	/// </summary>
	public class PriceLevel
	{
		/// <summary>
		/// ������� <see cref="PriceLevel"/>.
		/// </summary>
		/// <param name="price">����.</param>
		public PriceLevel(decimal price)
			: this(price, new List<decimal>(), new List<decimal>())
		{
		}

		/// <summary>
		/// ������� <see cref="PriceLevel"/>.
		/// </summary>
		/// <param name="price">����.</param>
		/// <param name="buyVolumes">��������� ������� �� �������.</param>
		/// <param name="sellVolumes">��������� ������� �� �������.</param>
		public PriceLevel(decimal price, List<decimal> buyVolumes, List<decimal> sellVolumes)
		{
			Price = price;

			BuyVolume = buyVolumes.Sum();
			SellVolume = sellVolumes.Sum();

			BuyCount = buyVolumes.Count;
			SellCount = sellVolumes.Count;

			BuyVolumes = buyVolumes;
			SellVolumes = sellVolumes;
		}

		/// <summary>
		/// ����.
		/// </summary>
		public decimal Price { get; private set; }

		/// <summary>
		/// ����� �������.
		/// </summary>
		public decimal BuyVolume { get; private set; }

		/// <summary>
		/// ����� ������.
		/// </summary>
		public decimal SellVolume { get; private set; }

		/// <summary>
		/// ���������� �������.
		/// </summary>
		public decimal BuyCount { get; private set; }

		/// <summary>
		/// ���������� ������.
		/// </summary>
		public decimal SellCount { get; private set; }

		/// <summary>
		/// ��������� ������� �� �������.
		/// </summary>
		public List<decimal> BuyVolumes { get; set; }

		/// <summary>
		/// ��������� ������� �� �������.
		/// </summary>
		public List<decimal> SellVolumes { get; set; }

		/// <summary>
		/// �������� ������� ������� ����� ���������.
		/// </summary>
		/// <param name="value">��������.</param>
		public void Update(ICandleBuilderSourceValue value)
		{
			var side = value.OrderDirection;

			if (side == null)
				throw new ArgumentOutOfRangeException();

			if (side == Sides.Buy)
			{
				BuyVolume += value.Volume;
				BuyCount++;
				BuyVolumes.Add(value.Volume);
			}
			else
			{
				SellVolume += value.Volume;
				SellCount++;
				SellVolumes.Add(value.Volume);
			}
		}
	}
}