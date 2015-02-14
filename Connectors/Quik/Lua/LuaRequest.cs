namespace StockSharp.Quik.Lua
{
	using StockSharp.Messages;

	/// <summary>
	/// ���������������� ������.
	/// </summary>
	public class LuaRequest
	{
		/// <summary>
		/// ������� <see cref="LuaRequest"/>.
		/// </summary>
		public LuaRequest()
		{
		}

		/// <summary>
		/// ��� ���������.
		/// </summary>
		public MessageTypes MessageType { get; set; }

		/// <summary>
		/// ����� ����������.
		/// </summary>
		public long TransactionId { get; set; }

		/// <summary>
		/// �������� �������.
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// ������������� �����������.
		/// </summary>
		public SecurityId? SecurityId { get; set; }

		/// <summary>
		/// ��� ������.
		/// </summary>
		public OrderTypes? OrderType { get; set; }
	}
}