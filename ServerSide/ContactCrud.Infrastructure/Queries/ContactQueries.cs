using System.Diagnostics.CodeAnalysis;

namespace CleanArch.Sql.Queries
{
    [ExcludeFromCodeCoverage]
	public static class ContactQueries
	{
		public static string AllContact => "SELECT * FROM [dbo].[Contact] (NOLOCK)";

		public static string ContactById => "SELECT * FROM [Contact] (NOLOCK) WHERE [ContactId] = @ContactId";

		public static string AddContact =>
			@"INSERT INTO [Contact] ([FirstName], [LastName], [Email], [PhoneNumber]) 
				VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";

		public static string UpdateContact =>
			@"UPDATE [Contact] 
            SET [FirstName] = @FirstName, 
				[LastName] = @LastName, 
				[Email] = @Email, 
				[PhoneNumber] = @PhoneNumber
            WHERE [ContactId] = @ContactId";

		public static string DeleteContact => "DELETE FROM [Contact] WHERE [ContactId] = @ContactId";

		public static string GetUpdateContactQuery(int cid)
		{
			return UpdateContact.Replace("@ContactId", cid.ToString());
		}
	}
}
