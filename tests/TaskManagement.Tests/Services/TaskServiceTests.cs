using FluentAssertions;
using Moq;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Services;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Tests.Services;

public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _repositoryMock;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _repositoryMock = new Mock<ITaskRepository>();
        _service = new TaskService(_repositoryMock.Object);
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateTask()
    {
        var dto = new CreateTaskDto
        {
            Title = "Test Task",
            Description = "Description",
            Status = Domain.Enums.TaskStatus.Pending
        };

        _repositoryMock
            .Setup(x => x.AddAsync(It.IsAny<TaskItem>()))
            .ReturnsAsync((TaskItem t) => t);

        var result = await _service.CreateAsync(dto);

        result.Should().NotBeNull();
        result.Title.Should().Be(dto.Title);

        _repositoryMock.Verify(
            x => x.AddAsync(It.IsAny<TaskItem>()),
            Times.Once);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenTaskDoesNotExist()
    {
        _repositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((TaskItem?)null);

        var result =
            await _service.GetByIdAsync(Guid.NewGuid());

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenTaskNotFound()
    {
        _repositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((TaskItem?)null);

        var result =
            await _service.DeleteAsync(Guid.NewGuid());

        result.Should().BeFalse();
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnFalse_WhenTaskNotFound()
    {
        var dto = new UpdateTaskDto
        {
            Title = "Updated",
            Status = Domain.Enums.TaskStatus.Completed
        };

        _repositoryMock
            .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((TaskItem?)null);

        var result =
            await _service.UpdateAsync(Guid.NewGuid(), dto);

        result.Should().BeFalse();
    }
}