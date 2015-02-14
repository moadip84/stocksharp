namespace StockSharp.Alor.Metadata
{
	using System;

	/// <summary>
	/// ������� ��������� ������� ALL_TRADES.
	/// </summary>
	public static class AlorTradeColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.Trade, "ID", typeof(int), false);

		/// <summary>
		/// ����� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn TradeNo = new AlorColumn(AlorTableTypes.Trade, "TradeNo", typeof(long));

		/// <summary>
		/// ����� ����������� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn Time = new AlorColumn(AlorTableTypes.Trade, "Time", typeof(DateTime));

		/// <summary>
		/// ������������� ������ ������ ��� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityBoard = new AlorColumn(AlorTableTypes.Trade, "SecBoard", typeof(string));

		/// <summary>
		/// ������������� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityCode = new AlorColumn(AlorTableTypes.Trade, "SecCode", typeof(string));

		/// <summary>
		/// ����� ������.
		/// </summary>
		public static readonly AlorColumn Volume = new AlorColumn(AlorTableTypes.Trade, "Quantity", typeof(int));

		/// <summary>
		/// ���� �� ���� ������ ������.
		/// </summary>
		public static readonly AlorColumn Price = new AlorColumn(AlorTableTypes.Trade, "Price", typeof(decimal));

		/// <summary>
		/// ����� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn State = new AlorColumn(AlorTableTypes.Trade, "RowState", typeof(long));

		/// <summary>
		/// ����� ������.
		/// </summary>
        public static readonly AlorColumn Value = new AlorColumn(AlorTableTypes.Trade, "Value", typeof(decimal), false);

		/// <summary>
		/// ����������.
		/// </summary>
        public static readonly AlorColumn Yield = new AlorColumn(AlorTableTypes.Trade, "Yield", typeof(decimal), false);

		/// <summary>
		/// ����������� �������� �����.
		/// </summary>
        public static readonly AlorColumn AccruedInt = new AlorColumn(AlorTableTypes.Trade, "AccruedInt", typeof(decimal), false);

		/// <summary>
		/// ������ ����.
		/// </summary>
        public static readonly AlorColumn RepoRate = new AlorColumn(AlorTableTypes.Trade, "RepoRate", typeof(decimal), false);

		/// <summary>
		/// ���� ����.
		/// </summary>
        public static readonly AlorColumn RepoTerm = new AlorColumn(AlorTableTypes.Trade, "RepoTerm", typeof(int), false);

		/// <summary>
		/// ��������� �������.
		/// </summary>
        public static readonly AlorColumn StartDiscount = new AlorColumn(AlorTableTypes.Trade, "StartDiscount", typeof(decimal), false);

		/// <summary>
		/// ������ �������� ������.
		/// </summary>
        public static readonly AlorColumn Period = new AlorColumn(AlorTableTypes.Trade, "Period", typeof(string), false);

		/// <summary>
		/// ��� ������.
		/// </summary>
		public static readonly AlorColumn Type = new AlorColumn(AlorTableTypes.Trade, "TradeType", typeof(string), false);

		/// <summary>
		/// ��� �������� �� ������.
		/// </summary>
        public static readonly AlorColumn SettlementCode = new AlorColumn(AlorTableTypes.Trade, "SettleCode", typeof(string), false);
	}
}