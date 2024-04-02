using ShowroomManagmentAPI.DTOs;

namespace ShowroomManagmentAPI.Repositories
{
    public interface ICustomer_segment
    {
        public Task<ResponseDTO> GetSegment();
        public Task<ResponseDTO> AddSegment(CustomerSegmentDTO customerSegmentDTO);
        public Task<ResponseDTO> DeleteSegment(int Id);
        public Task<ResponseDTO> GetSegmentById(int Id);
        public Task<ResponseDTO> UpdateSegment(CustomerSegmentDTO customerSegmentDTO);

    }
}
