namespace StockSharp.Alor.Metadata
{
	using System;

	/// <summary>
	/// ������� ��������� ������� TRADES.
	/// </summary>
	public static class AlorMyTradeColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.MyTrade, "ID", typeof(int), false);

		/// <summary>
		/// ����� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn TradeNo = new AlorColumn(AlorTableTypes.MyTrade, "TradeNo", typeof(long));

		/// <summary>
		/// ����� ������.
		/// </summary>
		public static readonly AlorColumn OrderNo = new AlorColumn(AlorTableTypes.MyTrade, "OrderNo", typeof(long));

		/// <summary>
		/// ����� ����������� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn Time = new AlorColumn(AlorTableTypes.MyTrade, "Time", typeof(DateTime));

		/// <summary>
		/// ������������� ������ ������ ��� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityBoard = new AlorColumn(AlorTableTypes.MyTrade, "SecBoard", typeof(string));

		/// <summary>
		/// ������������� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityCode = new AlorColumn(AlorTableTypes.MyTrade, "SecCode", typeof(string));

		/// <summary>
		/// ��� ������� ������ ������.
		/// </summary>
        public static readonly AlorColumn IssueCode = new AlorColumn(AlorTableTypes.MyTrade, "IssueCode", typeof(string), false);

		/// <summary>
		/// �������������� ������.
		/// </summary>
        public static readonly AlorColumn OrderDirection = new AlorColumn(AlorTableTypes.MyTrade, "BuySell", typeof(string));

		/// <summary>
		/// ����� ������.
		/// </summary>
		public static readonly AlorColumn Volume = new AlorColumn(AlorTableTypes.MyTrade, "Quantity", typeof(int));

		/// <summary>
		/// ���� �� ���� ������ ������.
		/// </summary>
		public static readonly AlorColumn Price = new AlorColumn(AlorTableTypes.MyTrade, "Price", typeof(decimal));

		/// <summary>
		/// ����� ������, � ���.
		/// </summary>
        public static readonly AlorColumn Value = new AlorColumn(AlorTableTypes.MyTrade, "Value", typeof(decimal), false);

		/// <summary>
		/// ����������.
		/// </summary>
        public static readonly AlorColumn Yield = new AlorColumn(AlorTableTypes.MyTrade, "Yield", typeof(decimal), false);

		/// <summary>
		/// ����������� �������� �����.
		/// </summary>
        public static readonly AlorColumn AccruedInt = new AlorColumn(AlorTableTypes.MyTrade, "AccruedInt", typeof(decimal), false);

		/// <summary>
		/// ������ ����.
		/// </summary>
        public static readonly AlorColumn RepoRate = new AlorColumn(AlorTableTypes.MyTrade, "RepoRate", typeof(decimal), false);

		/// <summary>
		/// ���� ����.
		/// </summary>
        public static readonly AlorColumn RepoTerm = new AlorColumn(AlorTableTypes.MyTrade, "RepoTerm", typeof(int), false);

		/// <summary>
		/// ��������� �������.
		/// </summary>
        public static readonly AlorColumn StartDiscount = new AlorColumn(AlorTableTypes.MyTrade, "StartDiscount", typeof(decimal), false);

		/// <summary>
		/// ����� �������� �� ������.
		/// </summary>
        public static readonly AlorColumn Commission = new AlorColumn(AlorTableTypes.MyTrade, "Commission", typeof(decimal), false);

		/// <summary>
		/// ������ �������� ������.
		/// </summary>
        public static readonly AlorColumn Period = new AlorColumn(AlorTableTypes.MyTrade, "Period", typeof(string), false);

		/// <summary>
		/// ��� ������.
		/// </summary>
        public static readonly AlorColumn Type = new AlorColumn(AlorTableTypes.MyTrade, "TradeType", typeof(string), false);

		/// <summary>
		/// ��� �������� �� ������.
		/// </summary>
        public static readonly AlorColumn SettlementCode = new AlorColumn(AlorTableTypes.MyTrade, "SettleCode", typeof(string), false);

		/// <summary>
		/// ������ ���� &lt;���� �������&gt;[/&lt;�������&gt;].
		/// </summary>
        public static readonly AlorColumn BrokerRef = new AlorColumn(AlorTableTypes.MyTrade, "BrokerRef", typeof(string), false);

	    /// <summary>
	    /// ��� �������.
	    /// </summary>
	    public static readonly AlorColumn BrokerId = new AlorColumn(AlorTableTypes.MyTrade, "BrokerID", typeof (string), false);

		/// <summary>
		/// ������������� ��������.
		/// </summary>
        public static readonly AlorColumn UserId = new AlorColumn(AlorTableTypes.MyTrade, "UserID", typeof(string), false);

		/// <summary>
		/// ������������� �����.
		/// </summary>
        public static readonly AlorColumn FirmId = new AlorColumn(AlorTableTypes.MyTrade, "FirmID", typeof(string), false);

		/// <summary>
		/// �������� ����.
		/// </summary>
        public static readonly AlorColumn Account = new AlorColumn(AlorTableTypes.MyTrade, "Account", typeof(string), false);

		/// <summary>
		/// ����-����������.
		/// </summary>
		public static readonly AlorColumn ExtRef = new AlorColumn(AlorTableTypes.MyTrade, "ExtRef", typeof(string));
	}
}