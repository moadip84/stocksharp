namespace StockSharp.Community
{
	using System.Security;

	using Ecng.Serialization;

	/// <summary>
	/// �����, �������� � ���� ����� � ������ ��� ������� � �������� http://stocksharp.com
	/// </summary>
	public sealed class ServerCredentials : IPersistable
	{
		/// <summary>
		/// ������� <see cref="ServerCredentials"/>.
		/// </summary>
		public ServerCredentials()
		{
			AutoLogon = true;
		}

		/// <summary>
		/// �����.
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// ������.
		/// </summary>
		public SecureString Password { get; set; }

		/// <summary>
		/// ������� �������������.
		/// </summary>
		public bool AutoLogon { get; set; }

		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="storage">��������� ��������.</param>
		public void Load(SettingsStorage storage)
		{
			Login = storage.GetValue<string>("Login");
			Password = storage.GetValue<SecureString>("Password");
			AutoLogon = storage.GetValue<bool>("AutoLogon");
		}

		/// <summary>
		/// ��������� ���������.
		/// </summary>
		/// <param name="storage">��������� ��������.</param>
		public void Save(SettingsStorage storage)
		{
			storage.SetValue("Login", Login);
			storage.SetValue("Password", Password);
			storage.SetValue("AutoLogon", AutoLogon);
		}
	}
}