using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName, CategoryStatus) values (@categoryname, @categorystatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryname", categoryDto.CategoryName);
            parameters.Add("@categorystatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "delete from Category where CategoryId = @categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "select * from Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            string query = "select * from Category where CategoryId =@categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryid", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCategoryDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "update Category set CategoryName = @categoryname, CategoryStatus = @categorystatus where CategoryId =@categoryid";
            var parameters = new DynamicParameters();
            parameters.Add("@categoryname", categoryDto.CategoryName);
            parameters.Add("@categorystatus", categoryDto.CategoryStatus);
            parameters.Add("@categoryid", categoryDto.CategoryId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
