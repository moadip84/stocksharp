namespace StockSharp.Quik.Native
{
	/// <summary>
	/// ��������� ���� (�������� � ���������) ���������� TRANS2QUIK.dll, ������� ���������� Quik.
	/// </summary>
	public enum Codes
	{
		/// <summary>
		/// ����� ������ �������.
		/// </summary>
		Success = 0,

		/// <summary>
		/// ��������� ������.
		/// </summary>
		Failed = 1,

		/// <summary>
		/// � ��������� �������� ���� ����������� INFO.EXE,
		/// ���� � ���� �� ������� ������ ��������� ������� �����������.
		/// </summary>
		QuikTerminalNotFound = 2,

		/// <summary>
		/// ������������ ������ Trans2QUIK.DLL ��������� INFO.EXE �� ��������������.
		/// </summary>
		DllVersionNotSupported = 3,

		/// <summary>
		/// ���������� ��� �����������.
		/// </summary>
		AlreadyConnectedToQuik = 4,

		/// <summary>
		/// ������������ ���������.
		/// </summary>
		WrongSyntax = 5,

		/// <summary>
		/// ����������� � �������� �� �����������.
		/// </summary>
		QuikNotConnected = 6,

		/// <summary>
		/// ����������� � ���������� �� �����������.
		/// </summary>
		DllNotConnected = 7,

		/// <summary>
		/// ����������� � Quik �����������.
		/// </summary>
		QuikConnected = 8,

		/// <summary>
		/// ����������� � Quik ���������.
		/// </summary>
		QuikDisconnected = 9,

		/// <summary>
		/// ����������� � ���������� �����������.
		/// </summary>
		DllConnected = 10,

		/// <summary>
		/// ����������� � ���������� ���������.
		/// </summary>
		DllDisconnected = 11,

		/// <summary>
		/// ������ ��������� ������.
		/// </summary>
		MemoryAllocationError = 12,

		/// <summary>
		/// ������������ ������������� ����������.
		/// </summary>
		WrongConnectionHandle = 13,

		/// <summary>
		/// ������������ ����� ����������.
		/// </summary>
		WrongInputParams = 14,
	}
}