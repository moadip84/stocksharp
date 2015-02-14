namespace StockSharp.Messages
{
	using System;

	/// <summary>
	/// ��������� ����������� ���������.
	/// </summary>
	public interface IMessageProcessor
	{
		/// <summary>
		/// <see langword="true"/>, ���� ���������� ��������� �������, ����� <see langword="false"/>.
		/// </summary>
		bool IsStarted { get; }

		/// <summary>
		/// ���������� ��������� � �������.
		/// </summary>
		int MessageCount { get; }

		/// <summary>
		/// ������������ ������ ������� ���������. 
		/// </summary>
		/// <remarks>
		/// �������� �� ��������� ����� -1, ��� ������������� ������� ��� �����������.
		/// </remarks>
		int MaxMessageCount { get; set; }

		/// <summary>
		/// ������� ��������� ������ ���������.
		/// </summary>
		event Action<Message, IMessageAdapter> NewMessage;

		/// <summary>
		/// ������� ��������� �����������.
		/// </summary>
		event Action Stopped;

		/// <summary>
		/// �������� ��������� � ������� �� ���������.
		/// </summary>
		/// <param name="message">���������.</param>
		/// <param name="adapter">�������.</param>
		/// <param name="force">�������� ��������� ���� � ������ ���������� ������� ������� <see cref="MaxMessageCount"/>.</param>
		void EnqueueMessage(Message message, IMessageAdapter adapter, bool force);

		/// <summary>
		/// ��������� ��������� ���������.
		/// </summary>
		void Start();

		/// <summary>
		/// ���������� ��������� ���������.
		/// </summary>
		void Stop();

		/// <summary>
		/// �������� ������� ��������� �� ���������� �������.
		/// </summary>
		/// <param name="message">������.</param>
		void Clear(ClearMessageQueueMessage message);
	}
}