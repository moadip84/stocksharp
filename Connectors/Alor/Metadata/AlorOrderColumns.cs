namespace StockSharp.Alor.Metadata
{
	using System;

	/// <summary>
	/// ������� ��������� ������� ORDERS.
	/// </summary>
	public static class AlorOrderColumns
	{
		/// <summary>
		/// ������������� ������.
		/// </summary>
		public static readonly AlorColumn Id = new AlorColumn(AlorTableTypes.Order, "ID", typeof(int), false);

		/// <summary>
		/// ����������������� ����� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn OrderNo = new AlorColumn(AlorTableTypes.Order, "OrderNo", typeof(long));

		/// <summary>
		/// ����� ����������� ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn Time = new AlorColumn(AlorTableTypes.Order, "Time", typeof(DateTime));

		/// <summary>
		/// ����� ������ (������) ������ � �������� �������.
		/// </summary>
		public static readonly AlorColumn CancelTime = new AlorColumn(AlorTableTypes.Order, "WithdrawTime", typeof(DateTime));

		/// <summary>
		/// ������� ��������� ������.
		/// </summary>
		public static readonly AlorColumn State = new AlorColumn(AlorTableTypes.Order, "Status", typeof(string));

		/// <summary>
		/// ��� ������.
		/// </summary>
		public static readonly AlorColumn Type = new AlorColumn(AlorTableTypes.Order, "MktLimit", typeof(string));

		/// <summary>
		/// �������������� ������.
		/// </summary>
		public static readonly AlorColumn Direction = new AlorColumn(AlorTableTypes.Order, "BuySell", typeof(string));

		/// <summary>
		/// ������� ����������� ����.
		/// </summary>
		public static readonly AlorColumn SplitPrice = new AlorColumn(AlorTableTypes.Order, "SplitFlag", typeof(string), false);

		/// <summary>
		/// ������� ����������.
		/// </summary>
		public static readonly AlorColumn ExecutionCondition = new AlorColumn(AlorTableTypes.Order, "ImmCancel", typeof(string));

		/// <summary>
		/// ������ ���� &lt;���� �������&gt;[/&lt;�������&gt;].
		/// </summary>
		public static readonly AlorColumn BrokerRef = new AlorColumn(AlorTableTypes.Order, "BrokerRef", typeof(string));

		/// <summary>
		/// ��� �������.
		/// </summary>
		public static readonly AlorColumn BrokerId = new AlorColumn(AlorTableTypes.Order, "BrokerID", typeof(string), false);

		/// <summary>
		/// ������������� ��������.
		/// </summary>
		public static readonly AlorColumn UserId = new AlorColumn(AlorTableTypes.Order, "UserID", typeof(string), false);

		/// <summary>
		/// ������������� �����.
		/// </summary>
		public static readonly AlorColumn FirmId = new AlorColumn(AlorTableTypes.Order, "FirmID", typeof(string), false);

		/// <summary>
		/// �������� ����.
		/// </summary>
		public static readonly AlorColumn Account = new AlorColumn(AlorTableTypes.Order, "Account", typeof(string));

		/// <summary>
		/// ������������� ������ ������ ��� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityBoard = new AlorColumn(AlorTableTypes.Order, "SecBoard", typeof(string));

		/// <summary>
		/// ������������� ����������� �����������.
		/// </summary>
		public static readonly AlorColumn SecurityCode = new AlorColumn(AlorTableTypes.Order, "SecCode", typeof(string));

		/// <summary>
		/// ���� �� ���� ������ ������.
		/// </summary>
		public static readonly AlorColumn Price = new AlorColumn(AlorTableTypes.Order, "Price", typeof(decimal));

		/// <summary>
		/// ���� ������ ������ ����� ����.
		/// </summary>
		public static readonly AlorColumn Price2 = new AlorColumn(AlorTableTypes.Order, "Price2", typeof(decimal), false);

		/// <summary>
		/// ���������� ������ �����.
		/// </summary>
		public static readonly AlorColumn Volume = new AlorColumn(AlorTableTypes.Order, "Quantity", typeof(int));

		/// <summary>
		/// ����� ������������� ����� ������.
		/// </summary>
		public static readonly AlorColumn Balance = new AlorColumn(AlorTableTypes.Order, "Balance", typeof(int));

		/// <summary>
		/// ����� ������ (��� ����� ������������� ����� ����� � % ������).
		/// </summary>
		public static readonly AlorColumn Value = new AlorColumn(AlorTableTypes.Order, "Value", typeof(decimal), false);

		/// <summary>
		/// ����������� �������� �����.
		/// </summary>
		public static readonly AlorColumn AccruedInt = new AlorColumn(AlorTableTypes.Order, "AccruedInt", typeof(decimal), false);

		/// <summary>
		/// ��� ����� �������� ����.
		/// </summary>
		public static readonly AlorColumn EnterType = new AlorColumn(AlorTableTypes.Order, "EnterType", typeof(string), false);

		/// <summary>
		/// ����������.
		/// </summary>
		public static readonly AlorColumn Yield = new AlorColumn(AlorTableTypes.Order, "Yield", typeof(decimal), false);

		/// <summary>
		/// ������ ������.
		/// </summary>
		public static readonly AlorColumn Period = new AlorColumn(AlorTableTypes.Order, "Period", typeof(string), false);

		/// <summary>
		/// ����-����������.
		/// </summary>
		public static readonly AlorColumn ExtRef = new AlorColumn(AlorTableTypes.Order, "ExtRef", typeof(string));

		/// <summary>
		/// ������ ������-�������.
		/// </summary>
		public static readonly AlorColumn MarketMaker = new AlorColumn(AlorTableTypes.Order, "MarketMaker", typeof(string), false);
	}
}