namespace StockSharp.Xaml
{
	using Ecng.Xaml;

	using StockSharp.Algo.Storages;

	/// <summary>
	/// ���������� ������ ��� ������ ���� �����������.
	/// </summary>
	public class StorageFormatComboBox : EnumComboBox
	{
		/// <summary>
		/// ������� <see cref="StorageFormatComboBox"/>.
		/// </summary>
		public StorageFormatComboBox()
		{
			EnumType = typeof(StorageFormats);
			SelectedFormat = StorageFormats.Binary;
		}

		/// <summary>
		/// ��������� ������.
		/// </summary>
		public StorageFormats SelectedFormat
		{
			get { return this.GetSelectedValue<StorageFormats>() ?? StorageFormats.Binary; }
			set { this.SetSelectedValue<StorageFormats>(value); }
		}
	}
}