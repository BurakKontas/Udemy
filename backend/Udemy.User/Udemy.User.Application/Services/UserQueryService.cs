namespace Udemy.User.Application.Services;

[QueryType]
public class UserQueryService()
{
    [GraphQLName("Query")]
    public async Task Query(CancellationToken cancellationToken)
    {

    }
}