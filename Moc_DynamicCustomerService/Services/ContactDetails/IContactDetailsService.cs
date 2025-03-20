// using Example.Models.ContactDetails;

// namespace Example.Services.ContactDetails;

// public interface IContactDetailsService
// {
//     Task<IEnumerable<ContactDetail>> GetAllAsync();
//     Task<ContactDetail?> GetByIdAsync(int id);
//     Task<ContactDetail> CreateAsync(ContactDetail contact);
//     Task<bool> DeleteAsync(int id);
//     Task<ContactDetail> UpdateAsync(int id, UpdateContactDetail dto);

//     // Nowa metoda (dodana w późniejszym czasie),
//     // z domyślną implementacją (C# 8.0+)
//     public virtual Task<bool> ArchiveAsync(int id)
//     {
//         // Domyślna implementacja - np. wyrzucamy wyjątek
//         // albo zwracamy jakąś stałą wartość.
//         throw new NotImplementedException("ArchiveAsync is not implemented yet.");
//     }
// };
