using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.VoucherUsage;
using backend.DataMapper;
using backend.IRepository;
using backend.Models;
using backend.Models.Data;

namespace backend.Repository
{
  public class VoucherUsageRepository : IVoucherUsageRepository
  {
    private readonly ApplicationDbContext _context;
    public VoucherUsageRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<VoucherUsage> CreateUseAsync(VoucherUsageDto voucherUsageDto)
    {
        var usage = voucherUsageDto.ToRecordUse();

        await _context.VoucherUsages.AddAsync(usage);

        await _context.SaveChangesAsync();

        return usage;
    }
  }
}