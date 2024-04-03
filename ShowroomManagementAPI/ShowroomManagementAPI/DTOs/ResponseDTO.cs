﻿namespace ShowroomManagmentAPI.DTOs
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public dynamic? Response { get; set; }
    }
}
