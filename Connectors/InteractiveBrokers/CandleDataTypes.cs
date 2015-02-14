namespace StockSharp.InteractiveBrokers
{
	using StockSharp.Messages;

	/// <summary>
	/// ���� ������, �� ������ ������� ������ ��������� �����.
	/// </summary>
	public static class CandleDataTypes
	{
		/// <summary>
		/// ������.
		/// </summary>
		public const Level1Fields Trades = Level1Fields.LastTradePrice;

		/// <summary>
		/// �������� ������.
		/// </summary>
		public const Level1Fields Midpoint = (Level1Fields)(-1);

		/// <summary>
		/// ������ ���.
		/// </summary>
		public const Level1Fields Bid = Level1Fields.BestBidPrice;

		/// <summary>
		/// ������ �����.
		/// </summary>
		public const Level1Fields Ask = Level1Fields.BestAskPrice;

		/// <summary>
		/// ������ ���� ���������.
		/// </summary>
		public const Level1Fields BidAsk = (Level1Fields)(-2);

		/// <summary>
		/// ������������� (���������������).
		/// </summary>
		public const Level1Fields ImpliedVolatility = Level1Fields.ImpliedVolatility;

		/// <summary>
		/// ������������� (������������).
		/// </summary>
		public const Level1Fields HistoricalVolatility = Level1Fields.HistoricalVolatility;

		/// <summary>
		/// ������ �������� �����.
		/// </summary>
		public const Level1Fields YieldAsk = (Level1Fields)(-3);

		/// <summary>
		/// ������ �������� ���.
		/// </summary>
		public const Level1Fields YieldBid = (Level1Fields)(-4);

		/// <summary>
		/// ������ �������� ���� ���������.
		/// </summary>
		public const Level1Fields YieldBidAsk = (Level1Fields)(-5);

		/// <summary>
		/// �������� ��������� ������.
		/// </summary>
		public const Level1Fields YieldLast = (Level1Fields)(-6);
	}
}