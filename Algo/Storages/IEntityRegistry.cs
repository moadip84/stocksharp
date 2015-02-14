namespace StockSharp.Algo.Storages
{
	using StockSharp.BusinessEntities;

	/// <summary>
	/// ���������, ����������� ��������� �������� ��������.
	/// </summary>
	public interface IEntityRegistry
	{
		/// <summary>
		/// ������ ����.
		/// </summary>
		IStorageEntityList<Exchange> Exchanges { get; }

		/// <summary>
		/// ������ �������� ��������.
		/// </summary>
		IStorageEntityList<ExchangeBoard> ExchangeBoards { get; }

		/// <summary>
		/// ������ ������������.
		/// </summary>
		IStorageSecurityList Securities { get; }

		/// <summary>
		/// ������ ���������.
		/// </summary>
		IStorageEntityList<Portfolio> Portfolios { get; }

		/// <summary>
		/// ������ �������.
		/// </summary>
		IStorageEntityList<Position> Positions { get; }

		/// <summary>
		/// ������ ����������� ������.
		/// </summary>
		IStorageEntityList<MyTrade> MyTrades { get; }

		/// <summary>
		/// ������ ������� ������.
		/// </summary>
		IStorageEntityList<Trade> Trades { get; }

		/// <summary>
		/// ������ ������.
		/// </summary>
		IStorageEntityList<Order> Orders { get; }

		/// <summary>
		/// ������ ������ ����������� � ������ ������.
		/// </summary>
		IStorageEntityList<OrderFail> OrderFails { get; }

		/// <summary>
		/// ������ ��������.
		/// </summary>
		IStorageEntityList<News> News { get; }
	}
}