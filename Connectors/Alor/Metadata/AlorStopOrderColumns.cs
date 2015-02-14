namespace StockSharp.Alor.Metadata
{
	using System;

	/// <summary>
	/// ������� ��������� ������� STOPORDERS.
	/// </summary>
	public static class AlorStopOrderColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.StopOrder, "ID", typeof(int), false);

		/// <summary>
		/// ����� ����-������.
		/// </summary>
		public static readonly AlorColumn OrderNo = new AlorColumn(AlorTableTypes.StopOrder, "OrderNo", typeof(long));

		/// <summary>
		/// ����� ����������� ����-������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn Time = new AlorColumn(AlorTableTypes.StopOrder, "Time", typeof(DateTime));

		/// <summary>
		/// ����� ������ (������) ����-������ � �������� �������.
		/// </summary>
        public static readonly AlorColumn CancelTime = new AlorColumn(AlorTableTypes.StopOrder, "WithdrawTime", typeof(DateTime));

		/// <summary>
		/// ������������� ������ ������ ��� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityBoard = new AlorColumn(AlorTableTypes.StopOrder, "SecBoard", typeof(string));

		/// <summary>
		/// ������������� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityCode = new AlorColumn(AlorTableTypes.StopOrder, "SecCode", typeof(string));

		/// <summary>
		/// �������������� ������.
		/// </summary>
		public static readonly AlorColumn Direction = new AlorColumn(AlorTableTypes.StopOrder, "BuySell", typeof(string));

		/// <summary>
		/// ��� ������.
		/// </summary>
		public static readonly AlorColumn Type = new AlorColumn(AlorTableTypes.StopOrder, "MktLimit", typeof(string), false);

		/// <summary>
		/// ������� ����������� ����.
		/// </summary>
		public static readonly AlorColumn SplitPrice = new AlorColumn(AlorTableTypes.StopOrder, "SplitFlag", typeof(string), false);

		/// <summary>
		/// ������� ����������.
		/// </summary>
		public static readonly AlorColumn ExecutionCondition = new AlorColumn(AlorTableTypes.StopOrder, "ImmCancel", typeof(string), false);

		/// <summary>
		/// ��� ����-������.
		/// </summary>
		public static readonly AlorColumn StopType = new AlorColumn(AlorTableTypes.StopOrder, "StopType", typeof(string));

		/// <summary>
		/// ����� ��������� �������� ����-������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn ExpiryTime = new AlorColumn(AlorTableTypes.StopOrder, "EndTime", typeof(DateTime));

		/// <summary>
		/// ���� ����������� ����-������.
		/// </summary>
		public static readonly AlorColumn StopPrice = new AlorColumn(AlorTableTypes.StopOrder, "AlertPrice", typeof(decimal));

		/// <summary>
		/// ���� �� ���� ������ ������.
		/// </summary>
		public static readonly AlorColumn Price = new AlorColumn(AlorTableTypes.StopOrder, "Price", typeof(decimal));

		/// <summary>
		/// ���������� ������ �����.
		/// </summary>
		public static readonly AlorColumn Volume = new AlorColumn(AlorTableTypes.StopOrder, "Quantity", typeof(int));

		/// <summary>
		/// ����������.
		/// </summary>
		public static readonly AlorColumn Yield = new AlorColumn(AlorTableTypes.StopOrder, "Yield", typeof(decimal), false);

		/// <summary>
		/// ����������� �������� �����.
		/// </summary>
		public static readonly AlorColumn AccruedInt = new AlorColumn(AlorTableTypes.StopOrder, "AccruedInt", typeof(decimal), false);

		/// <summary>
		/// ������� ��������� ������.
		/// </summary>
		public static readonly AlorColumn State = new AlorColumn(AlorTableTypes.StopOrder, "Status", typeof(string));

		/// <summary>
		/// ������ ���� &lt;���� �������&gt;[/&lt;�������&gt;].
		/// </summary>
		public static readonly AlorColumn BrokerRef = new AlorColumn(AlorTableTypes.StopOrder, "BrokerRef", typeof(string));

		/// <summary>
		/// ��� �������.
		/// </summary>
		public static readonly AlorColumn BrokerId = new AlorColumn(AlorTableTypes.StopOrder, "BrokerID", typeof(string), false);

		/// <summary>
		/// �������� ����.
		/// </summary>
		public static readonly AlorColumn Account = new AlorColumn(AlorTableTypes.StopOrder, "Account", typeof(string));

		/// <summary>
		/// ����-����������.
		/// </summary>
		public static readonly AlorColumn ExtRef = new AlorColumn(AlorTableTypes.StopOrder, "ExtRef", typeof(string));
	}
}