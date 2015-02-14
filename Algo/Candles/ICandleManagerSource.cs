namespace StockSharp.Algo.Candles
{
	/// <summary>
	/// �������� ������ ��� <see cref="ICandleManager"/>.
	/// </summary>
	public interface ICandleManagerSource : ICandleSource<Candle>
	{
		/// <summary>
		/// �������� ������, �������� ����������� ������ ��������.
		/// </summary>
		ICandleManager CandleManager { get; set; }
	}
}