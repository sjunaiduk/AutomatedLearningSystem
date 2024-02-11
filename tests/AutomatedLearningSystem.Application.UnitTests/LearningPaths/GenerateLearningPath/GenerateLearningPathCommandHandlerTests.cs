using AutomatedLearningSystem.Application.Common.Abstractions;
using AutomatedLearningSystem.Application.LearningPaths.Commands.GenerateLearningPath;
using AutomatedLearningSystem.Domain.Answers;
using AutomatedLearningSystem.Domain.Common;
using AutomatedLearningSystem.Domain.Users;
using FluentAssertions;
using NSubstitute;
using TestCommon.Constants;
using TestCommon.Factories;

namespace AutomatedLearningSystem.Application.UnitTests.LearningPaths.GenerateLearningPath;

public class GenerateLearningPathCommandHandlerTests
{
    private readonly IUserRepository _mockUserRepository = Substitute.For<IUserRepository>();
    private readonly ILearningItemsRepository _mockLearningItemsRepository = Substitute.For<ILearningItemsRepository>();
    private readonly ILearningPathRepository _mockLearningPathRepository = Substitute.For<ILearningPathRepository>();
    private readonly IQuestionRepository _mockQuestionRepository = Substitute.For<IQuestionRepository>();
    private readonly IUnitOfWork _mockUnitOfWork = Substitute.For<IUnitOfWork>();
    private readonly GenerateLearningPathCommandHandler _handler;

    private readonly IUserContext _userContext =
        Substitute.For<IUserContext>();
    public GenerateLearningPathCommandHandlerTests()
    {
        _handler = new(_mockLearningPathRepository,
            _mockUserRepository,
            _mockUnitOfWork,
            _mockQuestionRepository,
            _mockLearningItemsRepository,
            _userContext);
    }

    [Fact]

    public async Task Handler_ShouldReturnUserNotFound_WhenUserDoesntExist()
    {
        // Arrange
        _mockUserRepository.GetByIdAsync(Arg.Any<Guid>()).Returns((User?)null);
        _userContext.Id.Returns(UserConstants.Id);
        GenerateLearningPathCommand command = new(UserConstants.Id, new List<AnswerForQuestion>() { },
            UserProficiencyProfileFactory.Create(),
            LearningPathConstants.Name);
        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.FirstError.Should().Be(UserErrors.NotFound);

    }

    [Fact]
    public async Task Handler_ShouldReturnSuccess_WhenValidData()
    {
        // Arrange

        var user = User.Create(UserConstants.FirstName,
            UserConstants.LastName,
            UserConstants.Email,
            UserConstants.Role,
            UserConstants.Password,
            UserConstants.Id);
        _mockUserRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(user);
        _userContext.Id.Returns(UserConstants.Id);


        var question = QuestionFactory.Create(category: Category.Database);
        var profile = UserProficiencyProfileFactory.Create();
        var learningItems = LearningItemFactory.CreateMany(count: 25, category: Category.Database);
        var answers = AnswerForQuestionFactory.CreateMany(question, 5, user.Id, 30);
        _mockUserRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(user);
        _mockQuestionRepository.GetByIdAsync(question.Id).Returns(question);
        _mockLearningItemsRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(learningItems);
        var command = GenerateLearningPathCommandFactory.Create(user.Id,
            question,
            answers,
            profile);
        // Act
        var result = await _handler.Handle(command,
            default);

        // Assert
        result.FirstError.Should().BeNull();
        result.IsSuccess.Should().BeTrue();


    }

   

    [Fact]

    public async void Handler_ShouldGenerateLearningPathForAnyUser_WhenAuthenticatedUserIsAdmin()
    {
        // Arrange
        _userContext.Id.Returns(UserConstants.Id);
        _userContext.IsAdmin.Returns(true);
        var user = User.Create(UserConstants.FirstName,
            UserConstants.LastName,
            UserConstants.Email,
            UserConstants.Role,
            UserConstants.Password);
        _mockUserRepository.GetByIdAsync(Arg.Any<Guid>()).Returns(user);

        var question = QuestionFactory.Create(category: Category.Database);
        _mockQuestionRepository.GetByIdAsync(question.Id).Returns(question);

        var learningItems = LearningItemFactory.CreateMany(count: 25, category: Category.Database);
        _mockLearningItemsRepository.GetAllAsync(Arg.Any<CancellationToken>()).Returns(learningItems);


        var command = GenerateLearningPathCommandFactory.Create
        (userId: user.Id,
            question: question);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.FirstError.Should().BeNull();
        result.IsSuccess.Should().BeTrue();
    }
}