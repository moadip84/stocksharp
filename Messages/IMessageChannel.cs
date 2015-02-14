namespace StockSharp.Messages
{
	using System;

	/// <summary>
	/// ���������, ����������� ������������ ����� ���������.
	/// </summary>
	public interface IMessageChannel
	{
		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="message">���������.</param>
		void SendInMessage(Message message);

		/// <summary>
		/// ������� ��������� ������ ���������.
		/// </summary>
		event Action<Message> NewOutMessage;
	}
}