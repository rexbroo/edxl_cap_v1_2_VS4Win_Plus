using System;
using System.Threading.Tasks;

namespace edxl_cap_v1_2.Interfaces
{
    public interface IGetSelectedAlertIndex
    {
        Task GetSelectedAlertIndex(int AlertIndex);
        Task GetSelectedAlertIndex();
    }
}
