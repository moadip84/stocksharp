namespace StockSharp.OpenECry
{
	using System.Net;

	using Ecng.Common;

	/// <summary>
	/// ������ �������� ������� OpenECry.
	/// </summary>
	public static class OpenECryAddresses
	{
		/// <summary>
		/// ���� ������� �� ���������, ������ 9200.
		/// </summary>
		public const int DefaultPort = 9200;

		/// <summary>
		/// �������� ������. ����� api.openecry.com, ���� 9200.
		/// </summary>
		public static readonly EndPoint Api = "api.openecry.com:9200".To<EndPoint>();

		/// <summary>
		/// ���� ������. ����� sim.openecry.com, ���� 9200.
		/// </summary>
		public static readonly EndPoint Sim = "sim.openecry.com:9200".To<EndPoint>();
	}
}