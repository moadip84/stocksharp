namespace StockSharp.Messages
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// ��������� ������� ������.
	/// </summary>
	[DataContract]
	[Serializable]
	public enum OrderStatus : long
	{
		/// <summary>
		/// ���������� ���������� �� ������.
		/// </summary>
		[EnumMember]SentToServer = 0,

		/// <summary>
		/// ���������� �������� ��������.
		/// </summary>
		[EnumMember]ReceiveByServer = 1,

		/// <summary>
		/// ������ �������� ���������� �� �����.
		/// </summary>
		[EnumMember]GateError = 2,

		/// <summary>
		/// ���������� ������� ������.
		/// </summary>
		[EnumMember]Accepted = 3,

		/// <summary>
		/// ���������� �� ������� ������.
		/// </summary>
		[EnumMember]NotDone = 4,

		/// <summary>
		/// ���������� �� ������ �������� ������� �� �����-���� ���������.
		/// ��������, �������� �� ������� ���� � ������������ �� �������� ���������� ������� ����.
		/// </summary>
		[EnumMember]NotValidated = 5,

		/// <summary>
		/// ���������� �� ������ �������� ������� �������.
		/// </summary>
		[EnumMember]NotValidatedLimit = 6,

		/// <summary>
		/// ���������� �������, ����������� � ��������������, ������������ ���������� �����.
		/// </summary>
		[EnumMember]AcceptedByManager = 7,

		/// <summary>
		/// ���������� �������, ����������� � ��������������, �� ������������ ���������� �����.
		/// </summary>
		[EnumMember]NotAcceptedByManager = 8,

		/// <summary>
		/// ���������� �������, ����������� � ��������������, ����� ���������� �����.
		/// </summary>
		[EnumMember]CanceledByManager = 9,

		/// <summary>
		/// ���������� �� �������������� �������� ��������.
		/// </summary>
		[EnumMember]NotSupported = 10,

		/// <summary>
		/// ���������� �� ������ �������� ������������ ����������� �������. � �������, ���� �����,
		/// ������������������ �� �������, �� ������������� ������� ������������ ����������.
		/// </summary>
		[EnumMember]NotSigned = 11,

		/// <summary>
		/// ���������� ���������� �� ������ ������.
		/// </summary>
		[EnumMember]SentToCanceled = 12,

		/// <summary>
		/// ���������� �� ������� ������ ������.
		/// </summary>
		[EnumMember]Cancelled = 13,

		/// <summary>
		/// ���������� �� ������� ����������� ������.
		/// </summary>
		[EnumMember]Matched = 14,

		/// <summary>
		/// ���������� �� ����������� ������ ������.
		/// </summary>
		[EnumMember]RejectedBySystem = 15,
	}
}