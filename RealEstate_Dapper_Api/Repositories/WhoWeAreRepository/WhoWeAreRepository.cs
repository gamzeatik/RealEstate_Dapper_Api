using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;

        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAre)
        {
            string query = "insert into WhoWeAreDetail (Title, Subtitle, Description1, Description2) values (@title, @subtitle, @description1, @description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAre.Title);
            parameters.Add("@subtitle", createWhoWeAre.Subtitle);
            parameters.Add("@description1", createWhoWeAre.Description1);
            parameters.Add("@description2", createWhoWeAre.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "delete from WhoWeAreDetail where WhoWeAreDetailId = @whowearedetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailid", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "select * from WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetByIdWhoWeAreDetail(int id)
        {
            string query = "select * from WhoWeAreDetail where WhoWeAreDetailId = @whowearedetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@whowearedetailid", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
                return value;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetail)
        {
            string query = "update WhoWeAreDetail set Title = @title, Subtitle = @subtitle, Description1 =description1, Description2 = description2 where WhoWeAreDetailId =@whowearedetailid";
            var parameters = new DynamicParameters();
            parameters.Add("@title", updateWhoWeAreDetail.Title);
            parameters.Add("@subtitle", updateWhoWeAreDetail.Subtitle);
            parameters.Add("@description1", updateWhoWeAreDetail.Description1);
            parameters.Add("@description2", updateWhoWeAreDetail.Description2);
            parameters.Add("@whowearedetailid", updateWhoWeAreDetail.WhoWeAreDetailId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
