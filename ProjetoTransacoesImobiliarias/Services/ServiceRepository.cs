namespace ProjetoTransacoesImobiliarias.Services;

public class ServiceRepository
{
    public UserService UserService { get; private set; }
    public ClientService ClientService { get; private set; }
    public PropertyService PropertyService { get; private set; }
    public AuthenticationService AuthenticationService { get; private set; }

    public bool StartServices()
    {
        UserService = new UserService();
        if (!UserService.LoadUsersFromJson())
        {
            return false;
        }

        ClientService = new ClientService(UserService);
        ClientService.LoadClientsFromJson();

        PropertyService = new PropertyService(UserService, ClientService);
        PropertyService.LoadPropertiesFromJson();
        AuthenticationService = new AuthenticationService(UserService);

        return true;
    }
}