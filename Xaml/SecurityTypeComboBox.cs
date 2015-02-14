namespace StockSharp.Xaml
{
	using Ecng.Xaml;

	using StockSharp.Messages;

	/// <summary>
	/// ���������� ������ ��� ������ ���� �����������.
	/// </summary>
	public class SecurityTypeComboBox : EnumComboBox
	{
		private const SecurityTypes _nullType = (SecurityTypes)(-1);

		/// <summary>
		/// ������� <see cref="SecurityTypeComboBox"/>.
		/// </summary>
		public SecurityTypeComboBox()
		{
			EnumType = typeof(SecurityTypes);

			NullItem = new EnumComboBoxHelper.EnumerationMember
			{
				Description = string.Empty,
				Value = _nullType,
			};

			this.GetItemsSource().Insert(0, NullItem);

			SelectedType = null;
		}

		/// <summary>
		/// ������� ��� <see cref="SelectedType"/> ������� <see langword="null"/>.
		/// </summary>
		public EnumComboBoxHelper.EnumerationMember NullItem { get; private set; }

		/// <summary>
		/// ��������� ��� �����������.
		/// </summary>
		public SecurityTypes? SelectedType
		{
			get
			{
				var type = this.GetSelectedValue<SecurityTypes>();
				return type == _nullType ? null : type;
			}
			set
			{
				this.SetSelectedValue<SecurityTypes>(value ?? _nullType);
			}
		}
	}
}