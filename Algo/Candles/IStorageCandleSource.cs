namespace StockSharp.Algo.Candles
{
	using StockSharp.Algo.Storages;

	/// <summary>
	/// ��������� ��������� ������ ��� <see cref="ICandleManager"/>, ������� ��������� ������ �� �������� ���������.
	/// </summary>
	public interface IStorageCandleSource
	{
		/// <summary>
		/// ��������� ������.
		/// </summary>
		IStorageRegistry StorageRegistry { get; set; }
	}
}