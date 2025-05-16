namespace SimpleMDB;

public class MockUserService : IUserService
{
    private IUserRepository userRepository;

    public MockUserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<Result<PagedResult<User>>> ReadAll(int page, int size)
    {
        var pagedResult = await userRepository.ReadAll(page, size);
        
       var result = (pagedResult == null) ?
            new Result<PagedResult<User>>(new Exception("No results found.")):
            new Result<PagedResult<User>>(pagedResult);

            return await Task.FromResult(result);
    }
    public async Task<Result<User>> Create (User user)
    {
    User? createdUser = await userRepository.Create(user);

    var result = (createdUser == null) ?
            new Result<User>(new Exception("User could not be created")):
            new Result<User>(createdUser);

            return await Task.FromResult(result);

    }
    public async Task<Result<User>> Read(int id)
    {
        User? user = await userRepository.Read(id);

    var result = (user == null) ?
            new Result<User>(new Exception("User could not be read")):
            new Result<User>(user);

            return await Task.FromResult(result);
    }
    public async Task<Result<User>> Update(int id, User newUser)
    {
        User? user = await userRepository.Update(id, newUser);

    var result = (user == null) ?
            new Result<User>(new Exception("User could not be Updated")):
            new Result<User>(user);

            return await Task.FromResult(result);
    }
    public async Task<Result<User>> Delete(int id)
    {
       User? user = await userRepository.Delete(id);

    var result = (user == null) ?
            new Result<User>(new Exception("User could not be deleted")):
            new Result<User>(user);

            return await Task.FromResult(result);
    }
}
