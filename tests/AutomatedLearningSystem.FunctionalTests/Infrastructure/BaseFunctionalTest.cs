namespace AutomatedLearningSystem.FunctionalTests.Infrastructure;

public class BaseFunctionalTest : IClassFixture<FunctionalTestWebApplicationFactory>
{

    protected readonly HttpClient HttpClient;
    protected BaseFunctionalTest(FunctionalTestWebApplicationFactory factory)
    {
        HttpClient = factory.CreateClient();

    }
}