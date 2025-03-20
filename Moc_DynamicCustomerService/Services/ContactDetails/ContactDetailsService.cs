// using Example.Data;
// using Example.Models.ContactDetails;
// using Microsoft.EntityFrameworkCore;

// namespace Example.Services.ContactDetails;

// public class ContactDetailsService(AppDbContext context) : IContactDetailsService
// {
//     private readonly AppDbContext _context = context;

//     public async Task<IEnumerable<ContactDetail>> GetAllAsync()
//     {
//         return await _context.ContactDetails
//             .ToListAsync();
//     }

//     public async Task<ContactDetail?> GetByIdAsync(int id)
//     {
//         return await _context.ContactDetails.FindAsync(id);
//     }

//     public async Task<ContactDetail> CreateAsync(ContactDetail contact)
//     {
//         _context.ContactDetails.Add(contact);
//         await _context.SaveChangesAsync();
//         return contact;
//     }

//     public async Task<bool> DeleteAsync(int id)
//     {
//         var contact = await _context.ContactDetails.FindAsync(id);
//         if (contact == null)
//         {
//             return false;
//         }

//         _context.ContactDetails.Remove(contact);
//         await _context.SaveChangesAsync();
//         return true;
//     }

//     public async Task<ContactDetail> UpdateAsync(int id, UpdateContactDetail dto)
//     {
//         var contactDetail = await _context.ContactDetails.FindAsync(id) ?? throw new Exception("Contact not found");
//         contactDetail.Name = dto.Name ?? contactDetail.Name;
//         contactDetail.Email = dto.Email ?? contactDetail.Email;
//         contactDetail.Phone = dto.Phone ?? contactDetail.Phone;
//         if (dto.PaymentMethod.HasValue)
//         {
//             contactDetail.PaymentMethod = dto.PaymentMethod.Value;
//         }
//         contactDetail.Notes = dto.Notes;
        
//         // Aktualizacja relacji na podstawie ContactId (jeśli przekazano i jest inny)
//         if (dto.ContactId.HasValue && dto.ContactId.Value != contactDetail.ContactId)
//         {
//             var newContact = await _context.Contacts.FindAsync(dto.ContactId.Value) ?? throw new Exception($"Contact with ID {dto.ContactId.Value} not found.");
//             contactDetail.ContactId = newContact.Id;
//             contactDetail.Contact = newContact;
//         }

//         await _context.SaveChangesAsync();
//         return contactDetail;
//     }
// }