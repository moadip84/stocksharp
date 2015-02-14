namespace StockSharp.Algo.Candles.Compression
{
	using System;

	/// <summary>
	/// ��������� ����������� ������.
	/// </summary>
	public interface ICandleBuilder : ICandleManagerSource
	{
		/// <summary>
		/// ��� �����.
		/// </summary>
		Type CandleType { get; }

		/// <summary>
		/// ��������� ������.
		/// </summary>
		ICandleBuilderSourceList Sources { get; }

		/// <summary>
		/// K�������� ������.
		/// </summary>
		ICandleBuilderContainer Container { get; }
	}
}