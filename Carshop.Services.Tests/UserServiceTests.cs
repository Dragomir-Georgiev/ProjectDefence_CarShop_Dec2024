using CarShop.Data.Models;
using CarShop.Services.Data;
using Microsoft.AspNetCore.Identity;
using MockQueryable;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carshop.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<UserManager<ApplicationUser>> _mockUserManager;
        private Mock<RoleManager<IdentityRole<Guid>>> _mockRoleManager;
        private UserService _userService;

        [SetUp]
        public void SetUp()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            var roleStoreMock = new Mock<IRoleStore<IdentityRole<Guid>>>();
            _mockRoleManager = new Mock<RoleManager<IdentityRole<Guid>>>(
                roleStoreMock.Object, null, null, null, null);

            _userService = new UserService(_mockUserManager.Object, _mockRoleManager.Object);
        }

        [Test]
        public async Task GetAllUsersAsyncShouldReturnAllUsers()
        {
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F"), Email = "user1@test.com" },
                new ApplicationUser { Id = Guid.Parse("51527F81-BE89-4009-BBE7-A9094E7CB5BF"), Email = "user2@test.com" }
            }
            .BuildMock();

            _mockUserManager.Setup(m => m.Users)
                .Returns(users);

            var result = await _userService.GetAllUsersAsync();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Email, Is.EqualTo("user1@test.com"));
        }

        [Test]
        public async Task UserExistsByIdAsyncShouldReturnTrueIfTheUserExists()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");

            _mockUserManager.Setup(manager => manager.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(new ApplicationUser { Id = userId });

            var result = await _userService.UserExistsByIdAsync(userId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task UserExistsByIdAsyncShouldReturnFalseIfTheUserDoesNotExist()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");

            _mockUserManager.Setup(manager => manager.FindByIdAsync(userId.ToString()))
                .ReturnsAsync((ApplicationUser?)null);

            var result = await _userService.UserExistsByIdAsync(userId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task AssignUserToRoleAsyncShouldReturnTrueIfTheRoleIsAssigned()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");
            var roleName = "Admin";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager.Setup(manager => manager.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);

            _mockRoleManager.Setup(manager => manager.RoleExistsAsync(roleName))
                .ReturnsAsync(true);

            _mockUserManager.Setup(manager => manager.IsInRoleAsync(user, roleName))
                .ReturnsAsync(false);

            _mockUserManager.Setup(manager => manager.AddToRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _userService.AssignUserToRoleAsync(userId, roleName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AssignUserToRoleAsyncShouldReturnFalseIfTheRoleIsNotAssigned()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");
            var roleName = "Admin";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager.Setup(manager => manager.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);

            _mockRoleManager.Setup(manager => manager.RoleExistsAsync(roleName))
                .ReturnsAsync(true);

            _mockUserManager.Setup(manager => manager.IsInRoleAsync(user, roleName))
                .ReturnsAsync(false);

            _mockUserManager.Setup(manager => manager.AddToRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Failed());

            var result = await _userService.AssignUserToRoleAsync(userId, roleName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task AssignUserToRoleAsyncShouldReturnFalseIfTheRoleDoesNotExist()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");
            var roleName = "NonExistentRole";

            _mockRoleManager.Setup(manager => manager.RoleExistsAsync(roleName))
                .ReturnsAsync(false);

            var result = await _userService.AssignUserToRoleAsync(userId, roleName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task RemoveUserRoleAsyncShouldReturnTrueIfTheRoleIsRemoved()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");
            var roleName = "Admin";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager.Setup(manager => manager.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);

            _mockRoleManager.Setup(manager => manager.RoleExistsAsync(roleName))
                .ReturnsAsync(true);

            _mockUserManager.Setup(manager => manager.IsInRoleAsync(user, roleName))
                .ReturnsAsync(true);

            _mockUserManager.Setup(manager => manager.RemoveFromRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Success);

            var result = await _userService.RemoveUserRoleAsync(userId, roleName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task RemoveUserRoleAsyncShouldReturnFalseIfTheRoleIsNotRemoved()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");
            var roleName = "Admin";
            var user = new ApplicationUser { Id = userId };

            _mockUserManager.Setup(manager => manager.FindByIdAsync(userId.ToString()))
                .ReturnsAsync(user);

            _mockRoleManager.Setup(manager => manager.RoleExistsAsync(roleName))
                .ReturnsAsync(true);

            _mockUserManager.Setup(manager => manager.IsInRoleAsync(user, roleName))
                .ReturnsAsync(true);

            _mockUserManager.Setup(manager => manager.RemoveFromRoleAsync(user, roleName))
                .ReturnsAsync(IdentityResult.Failed());

            var result = await _userService.RemoveUserRoleAsync(userId, roleName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task RemoveUserRoleAsyncShouldReturnFalseIfTheRoleDoesNotExist()
        {
            var userId = Guid.Parse("A64135D0-607F-470C-929B-D7D99B62192F");
            var roleName = "NonExistentRole";

            _mockRoleManager.Setup(manager => manager.RoleExistsAsync(roleName))
                .ReturnsAsync(false);

            var result = await _userService.RemoveUserRoleAsync(userId, roleName);

            Assert.That(result, Is.False);
        }
    }
}
