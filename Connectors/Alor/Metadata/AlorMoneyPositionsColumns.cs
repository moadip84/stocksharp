namespace StockSharp.Alor.Metadata
{
	/// <summary>
	/// ������� ��������� ������� POSITIONS.
	/// </summary>
	public static class AlorMoneyPositionsColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.Money, "ID", typeof(int), false);

		/// <summary>
		/// ������������� �������.
		/// </summary>
		public static readonly AlorColumn ClientId = new AlorColumn(AlorTableTypes.Money, "ClientID", typeof(int), false);

		/// <summary>
		/// ����� ��������� �����.
		/// </summary>
		public static readonly AlorColumn Account = new AlorColumn(AlorTableTypes.Money, "Account", typeof(string));

		/// <summary>
		/// ������ ���� &lt;���� �������&gt;[/&lt;�������&gt;].
		/// </summary>
		public static readonly AlorColumn BrokerRef = new AlorColumn(AlorTableTypes.Money, "BrokerRef", typeof(string), false);

		/// <summary>
		/// �������� ������� � ������� �������� ������� �� ����� �������.
		/// </summary>
		public static readonly AlorColumn BeginValue = new AlorColumn(AlorTableTypes.Money, "OpenBal", typeof(decimal));

		/// <summary>
		/// ������� ������� � �������� ������� ���� ��������� ����� ����������� �������� ������ �� ������� ����� ��������� ����� ������ �� �������.
		/// </summary>
		public static readonly AlorColumn CurrentValue = new AlorColumn(AlorTableTypes.Money, "CurrentPos", typeof(decimal));

		/// <summary>
		/// ����� �������� ������ �� ������� � ��������� ����������������� ����� ���� �������� ������ �� �������, � ���.
		/// </summary>
		public static readonly AlorColumn CurrentBidsVolume = new AlorColumn(AlorTableTypes.Money, "OrderBuy", typeof(decimal), false);

		/// <summary>
		/// ����� �������� ������ �� ������� � ��������� ����������������� ����� ���� �������� ������ �� �������, � ���.
		/// </summary>
		public static readonly AlorColumn CurrentAsksVolume = new AlorColumn(AlorTableTypes.Money, "OrderSell", typeof(decimal), false);

		/// <summary>
		/// ��������� �������� �������� �� �������� �����, � ���.
		/// </summary>
		public static readonly AlorColumn TotalPortfolio = new AlorColumn(AlorTableTypes.Money, "Portfolio", typeof(decimal), false);

		/// <summary>
		/// ��������� ����� � ������� �� ������� �������� ������, � ���.
		/// </summary>
		public static readonly AlorColumn TotalTrades = new AlorColumn(AlorTableTypes.Money, "Value", typeof(decimal), false);

		/// <summary>
		/// �������� ����, � ���.
		/// </summary>
        public static readonly AlorColumn MarketCommission = new AlorColumn(AlorTableTypes.Money, "Commission", typeof(decimal));

		/// <summary>
		/// �������� �������, � ���.
		/// </summary>
		public static readonly AlorColumn BrokerCommission = new AlorColumn(AlorTableTypes.Money, "Commission2", typeof(decimal));

		/// <summary>
		/// ����������� �������� ���� (����������� ������������ ������), � ���.
		/// </summary>
		public static readonly AlorColumn MarketPlannedCommission = new AlorColumn(AlorTableTypes.Money, "PlannedCommission", typeof(decimal), false);

		/// <summary>
		/// ����������� �������� ������� (����������� ������������ ������), � ���.
		/// </summary>
		public static readonly AlorColumn BrokerPlannedCommission = new AlorColumn(AlorTableTypes.Money, "PlannedCommission2", typeof(decimal), false);

		/// <summary>
		/// �����, � ���.
		/// </summary>
		public static readonly AlorColumn PnL = new AlorColumn(AlorTableTypes.Money, "Profit", typeof(decimal), false);

		/// <summary>
		/// ��������� ��������.
		/// </summary>
		public static readonly AlorColumn Free = new AlorColumn(AlorTableTypes.Money, "Free", typeof(decimal), false);

		/// <summary>
		/// ��������� �������� ��������� ������� ��� �������� ������, � ���.
		/// </summary>
		public static readonly AlorColumn FreeForShorting = new AlorColumn(AlorTableTypes.Money, "FreeForShorting", typeof(decimal), false);

		/// <summary>
		/// ��������� �������� ��������� ������� ��� ������� ������������ �����, � ���.
		/// </summary>
		public static readonly AlorColumn FreeForMargin = new AlorColumn(AlorTableTypes.Money, "FreeForMargin", typeof(decimal), false);

		/// <summary>
		/// ��������� �������� ��������� ������� ��� ������� �������������� �����, � ���.
		/// </summary>
		public static readonly AlorColumn FreeForNonMargin = new AlorColumn(AlorTableTypes.Money, "FreeForNonMargin", typeof(decimal), false);

		/// <summary>
		/// ������� ������� �����.
		/// </summary>
		public static readonly AlorColumn MarginLevel = new AlorColumn(AlorTableTypes.Money, "MarginLevel", typeof(decimal), false);

		/// <summary>
		/// ����������� ������� ����� (� ������ ������������ ������).
		/// </summary>
		public static readonly AlorColumn MarginPlannedLevel = new AlorColumn(AlorTableTypes.Money, "MarginLevelPlanned", typeof(decimal), false);

		/// <summary>
		/// ������������� �����.
		/// </summary>
		public static readonly AlorColumn FirmId = new AlorColumn(AlorTableTypes.Money, "FirmID", typeof(string), false);

		/// <summary>
		/// ��� ������.
		/// </summary>
		public static readonly AlorColumn Currency = new AlorColumn(AlorTableTypes.Money, "CurrCode", typeof(string), false);

		/// <summary>
		/// ��� �������.
		/// </summary>
		public static readonly AlorColumn Code = new AlorColumn(AlorTableTypes.Money, "Tag", typeof(string), false);

		/// <summary>
		/// ������� �����, � ���.
		/// </summary>
		public static readonly AlorColumn Limit = new AlorColumn(AlorTableTypes.Money, "CBPLimit", typeof(decimal), false);

		/// <summary>
		/// ����������� �� ������� ������������ �����, ������������ �� ������� ���������, � ���.
		/// </summary>
		public static readonly AlorColumn VarMargin = new AlorColumn(AlorTableTypes.Money, "VarMargin", typeof(decimal), false);

		/// <summary>
        /// ��� ����� ("0" � ������, "1" � ������)
        /// </summary>
        public static readonly AlorColumn AccCode = new AlorColumn(AlorTableTypes.Money, "AccCode", typeof(string));
	}
}