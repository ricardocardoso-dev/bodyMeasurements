namespace api.Utils
{
    public static class EnumHelper
	{
		public static string GetEnumData<T>() where T : Enum
		{
			Type enumType = typeof(T);
			string[] enumNames = Enum.GetNames(enumType);
			Array enumValues = Enum.GetValues(enumType);
			string enumData = "";

			for (int i = 0; i < enumNames.Length; i++)
				enumData += $"{(int)enumValues.GetValue(i)} - {enumNames[i]} /";
			
			return enumData;
		}
	}
}