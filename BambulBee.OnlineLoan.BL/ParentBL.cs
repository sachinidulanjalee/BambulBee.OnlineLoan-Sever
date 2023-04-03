using AutoMapper;
using DMS.LIBRAYMANAGMANT.MODEL;
using DMS.LIBRAYMANAGMANT.REPOSITORY;
using DMS.LIBRAYMANAGMANT.REPOSITORY.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMS.LIBRAYMANAGMANT.BL
{
  public class ParentBL
  {
    public List<MainClassificationsModel> GetAllMainClassificationsModel()
    {
      try
      {
        using (DataAdapter adapter = new DataAdapter())
        {


          List<MainClassificationsModel> lstMainClassificationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<MainClassifications, MainClassificationsModel>(); }))
            .CreateMapper()).Map<List<MainClassifications>, List<MainClassificationsModel>>(adapter.MainClassificationsRepository.GetAll());

          List<SubClassificationsModel> lstSubClassificationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<SubClassifications, SubClassificationsModel>(); }))
             .CreateMapper()).Map<List<SubClassifications>, List<SubClassificationsModel>>(adapter.SubClassificationsRepository.GetAll());

          List<LocationsModel> lstLocationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Locations, LocationsModel>(); })).
            CreateMapper()).Map<List<Locations>, List<LocationsModel>>(adapter.LocationsRepository.GetAll());

          List<BooksModel> lstBooksModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Books, BooksModel>(); })).
            CreateMapper()).Map<List<Books>, List<BooksModel>>(adapter.BooksRepository.GetAll());

          lstMainClassificationsModel = lstMainClassificationsModel.Select(x => new MainClassificationsModel()
          {
            ClassificationID = x.ClassificationID,
            DescriptionEnglish = x.DescriptionEnglish,
            DescriptionSinhala = x.DescriptionSinhala,
            CreatedDateTime = x.CreatedDateTime,
            CreatedBy = x.CreatedBy,
            CreatedMachine = x.CreatedMachine,
            ModifiedDateTime = x.ModifiedDateTime,
            ModifiedBy = x.ModifiedBy,
            ModifiedMachine = x.ModifiedMachine,
            IsPrimaryKeyExist = (lstSubClassificationsModel.FindAll(y => y.ClassificationID == x.ClassificationID).Count() != 0 ||
                                  lstLocationsModel.FindAll(y => y.ClassificationID == x.ClassificationID).Count() != 0 ||
                                  lstBooksModel.FindAll(y => y.ClassificationID == x.ClassificationID).Count() != 0),
          }).ToList();

          return lstMainClassificationsModel;

        }
      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

    public List<SubClassificationsModel> GetAllSubClassificationsModel()
    {
      try
      {
        using (DataAdapter adapter = new DataAdapter())
        {

          List<MainClassificationsModel> lstMainClassificationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<MainClassifications, MainClassificationsModel>(); }))
              .CreateMapper()).Map<List<MainClassifications>, List<MainClassificationsModel>>(adapter.MainClassificationsRepository.GetAll());

          List<SubClassificationsModel> lstSubClassificationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<SubClassifications, SubClassificationsModel>(); }))
             .CreateMapper()).Map<List<SubClassifications>, List<SubClassificationsModel>>(adapter.SubClassificationsRepository.GetAll());

          List<LocationsModel> lstLocationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Locations, LocationsModel>(); })).
           CreateMapper()).Map<List<Locations>, List<LocationsModel>>(adapter.LocationsRepository.GetAll());

          List<BooksModel> lstBooksModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Books, BooksModel>(); })).
            CreateMapper()).Map<List<Books>, List<BooksModel>>(adapter.BooksRepository.GetAll());


          lstSubClassificationsModel = (from a in lstSubClassificationsModel
                                        join b in lstMainClassificationsModel
                                        on a.ClassificationID equals b.ClassificationID
                                        select new SubClassificationsModel()
                                        {
                                          SubClassificationID = a.SubClassificationID,
                                          ClassificationID = a.ClassificationID,
                                          DescriptionEnglish = a.DescriptionEnglish,
                                          DescriptionSinhala = a.DescriptionSinhala,
                                          CreatedDateTime = a.CreatedDateTime,
                                          CreatedBy = a.CreatedBy,
                                          CreatedMachine = a.CreatedMachine,
                                          ModifiedDateTime = a.ModifiedDateTime,
                                          ModifiedBy = a.ModifiedBy,
                                          ModifiedMachine = a.ModifiedMachine,
                                          ClassificationName = b.DescriptionEnglish,
                                          IsPrimaryKeyExist =  (lstLocationsModel.FindAll(x => x.SubClassificationID == a.SubClassificationID).Count() != 0) ||
                                                              (lstBooksModel.FindAll(x => x.SubClassificationID == a.SubClassificationID).Count() != 0) 
                                        }).ToList();


          return lstSubClassificationsModel;
        }

      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

    public List<LocationsModel> GetAllLocationsModel()
    {
      try
      {
        using (DataAdapter adapter = new DataAdapter())
        {

          List<SubClassificationsModel> lstSubClassificationsModel = GetAllSubClassificationsModel();

          List<LocationsModel> lstLocationsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Locations, LocationsModel>(); })).
           CreateMapper()).Map<List<Locations>, List<LocationsModel>>(adapter.LocationsRepository.GetAll());



          lstLocationsModel = (from a in lstLocationsModel
                               join b in lstSubClassificationsModel
                               on a.SubClassificationID equals b.SubClassificationID
                               select new LocationsModel()
                               {
                                 SubClassificationID = a.SubClassificationID,
                                 ClassificationID = a.ClassificationID,
                                 LocationID = a.LocationID,
                                 Description = a.Description,
                                 CreatedDateTime = a.CreatedDateTime,
                                 CreatedBy = a.CreatedBy,
                                 CreatedMachine = a.CreatedMachine,
                                 ModifiedDateTime = a.ModifiedDateTime,
                                 ModifiedBy = a.ModifiedBy,
                                 ModifiedMachine = a.ModifiedMachine,
                                 ClassificationName = b.ClassificationName,
                                 SubClassificationName = b.DescriptionEnglish,
                                 IsPrimaryKeyExist = false,
                               }).ToList();


          return lstLocationsModel;
        }

      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

    public List<BooksModel> GetAllBooksModel()
    {
      try
      {
        using (DataAdapter adapter = new DataAdapter())
        {
          List<BooksModel> lstBooksModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Books, BooksModel>(); })).
            CreateMapper()).Map<List<Books>, List<BooksModel>>(adapter.BooksRepository.GetAll());

          List<MembersModel> lstMembersModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Members, MembersModel>(); }))
            .CreateMapper()).Map<List<Members>, List<MembersModel>>(adapter.MambersRepository.GetAll());

          //List<SubClassificationsModel> lstSubClassificationsModel = ((new MapperConfiguration(cfg =>
          //{ cfg.CreateMap<SubClassifications, SubClassificationsModel>(); }))
          //   .CreateMapper()).Map<List<SubClassifications>, List<SubClassificationsModel>>(adapter.SubClassificationsRepository.GetAll());
          List<SubClassificationsModel> lstSubClassificationsModel = GetAllSubClassificationsModel();

          List<LendingDetailsModel> lstLendingDetailsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<LendingDetails, LendingDetailsModel>(); }))
            .CreateMapper()).Map<List<LendingDetails>, List<LendingDetailsModel>>(adapter.LendingDetailsRepository.GetAll());


          lstBooksModel = (from a in lstBooksModel
                           join b in lstSubClassificationsModel
                           on a.SubClassificationID equals b.SubClassificationID
                           join c in lstMembersModel
                           on a.MemberID equals c.MembershipID into bookjoin
                           from d in bookjoin.DefaultIfEmpty()
                           select new BooksModel()
                           {
                             BookID = a.BookID,
                             ClassificationID = a.ClassificationID,
                             SubClassificationID = a.SubClassificationID,
                             MemberID = a.MemberID,
                             DescriptionEnglish = a.DescriptionEnglish,
                             DescriptionSinhala = a.DescriptionSinhala,
                             Auhtors = a.Auhtors,
                             Publisher = a.Publisher,
                             Edition = a.Edition,
                             Year = a.Year,
                             Series = a.Series,
                             Language = a.Language,
                             Pages = a.Pages,
                             DDSCode = a.DDSCode,
                             ISBN = a.ISBN,
                             Status = a.Status,
                             LendedDate = a.LendedDate,
                             CreatedDateTime = a.CreatedDateTime,
                             CreatedBy = a.CreatedBy,
                             CreatedMachine = a.CreatedMachine,
                             ModifiedDateTime = a.ModifiedDateTime,
                             ModifiedBy = a.ModifiedBy,
                             ModifiedMachine = a.ModifiedMachine,
                             ClassificationName = b.ClassificationName,
                             SubClassificationName = b.DescriptionEnglish,
                             MemberName = d == null ? string.Empty : d.FirstName + " " + d.Surname,
                           }).ToList();

          lstBooksModel = lstBooksModel.GroupBy(x => x.BookID).Select(x => new BooksModel()
          {
            BookID = x.First().BookID,
            ClassificationID = x.First().ClassificationID,
            SubClassificationID = x.First().SubClassificationID,
            MemberID = x.First().MemberID,
            DescriptionEnglish = x.First().DescriptionEnglish,
            DescriptionSinhala = x.First().DescriptionSinhala,
            Auhtors = x.First().Auhtors,
            Publisher = x.First().Publisher,
            Edition = x.First().Edition,
            Year = x.First().Year,
            Series = x.First().Series,
            Language = x.First().Language,
            Pages = x.First().Pages,
            DDSCode = x.First().DDSCode,
            ISBN = x.First().ISBN,
            Status = x.First().Status,
            LendedDate = x.First().LendedDate,
            CreatedDateTime = x.First().CreatedDateTime,
            CreatedBy = x.First().CreatedBy,
            CreatedMachine = x.First().CreatedMachine,
            ModifiedDateTime = x.First().ModifiedDateTime,
            ModifiedBy = x.First().ModifiedBy,
            ModifiedMachine = x.First().ModifiedMachine,
            ClassificationName = x.First().ClassificationName,
            SubClassificationName = x.First().SubClassificationName,
            MemberName = x.First().MemberName,
            IsPrimaryKeyExist = (lstLendingDetailsModel.FindAll(y => y.BookID == x.First().BookID).Count() != 0)
          }).ToList();

          return lstBooksModel;

        }
      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

    public List<MembersModel> GetAllMembersModel()
    {
      try
      {

        using (DataAdapter adapter = new DataAdapter())
        {
          List<MembersModel> lstMembersModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Members, MembersModel>(); }))
            .CreateMapper()).Map<List<Members>, List<MembersModel>>(adapter.MambersRepository.GetAll());

          List<LendingDetailsModel> lstLendingDetailsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<LendingDetails, LendingDetailsModel>(); }))
            .CreateMapper()).Map<List<LendingDetails>, List<LendingDetailsModel>>(adapter.LendingDetailsRepository.GetAll());


          lstMembersModel = lstMembersModel.Select(x => new MembersModel()
          {
            MembershipID = x.MembershipID,
            MembershipCode = x.MembershipCode,
            NICPassport = x.NICPassport,
            Title = x.Title,
            Sex = x.Sex,
            Surname = x.Surname,
            FirstName = x.FirstName,
            ShortName = x.ShortName,
            Nationality = x.Nationality,
            Address01 = x.Address01,
            Address02 = x.Address02,
            Address03 = x.Address03,
            City = x.City,
            Province = x.Province,
            PostalCode = x.PostalCode,
            Country = x.Country,
            Telephone = x.Telephone,
            Mobile = x.Mobile,
            Email = x.Email,
            Status = x.Status,
            CreatedDateTime = x.CreatedDateTime,
            CreatedBy = x.CreatedBy,
            CreatedMachine = x.CreatedMachine,
            ModifiedDateTime = x.ModifiedDateTime,
            ModifiedBy = x.ModifiedBy,
            ModifiedMachine = x.ModifiedMachine,
            IsPrimaryKeyExist = (lstLendingDetailsModel.FindAll(y => y.MembershipID == x.MembershipID).Count() != 0 ),
          }).ToList();

          return lstMembersModel;
        }
      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

    public List<LendingDetailsModel> GetAllLendingDetailsModel()
    {
      try
      {
       
        using (DataAdapter adapter = new DataAdapter())
        {
          List<LendingDetailsModel> lstLendingDetailsModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<LendingDetails, LendingDetailsModel>(); }))
            .CreateMapper()).Map<List<LendingDetails>, List<LendingDetailsModel>>(adapter.LendingDetailsRepository.GetAll());

          List<MembersModel> lstMembersModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Members, MembersModel>(); }))
            .CreateMapper()).Map<List<Members>, List<MembersModel>>(adapter.MambersRepository.GetAll());

          List<BooksModel> lstBooksModel = ((new MapperConfiguration(cfg =>
          { cfg.CreateMap<Books, BooksModel>(); })).
            CreateMapper()).Map<List<Books>, List<BooksModel>>(adapter.BooksRepository.GetAll());

          lstLendingDetailsModel = (from a in lstLendingDetailsModel
                                    join b in lstBooksModel
                                    on a.BookID equals b.BookID
                                    join c in lstMembersModel
                                    on a.MembershipID equals c.MembershipID
                                    select new LendingDetailsModel()
                                    {
                                      LendingID = a.LendingID,
                                      MembershipID = a.MembershipID,
                                      BookID = a.BookID,
                                      LendedDate = a.LendedDate,
                                      ExpiryPeriod = a.ExpiryPeriod,
                                      CollectedDate = a.CollectedDate,
                                      Status = a.Status,
                                      CreatedDateTime = a.CreatedDateTime,
                                      CreatedBy = a.CreatedBy,
                                      CreatedMachine = a.CreatedMachine,
                                      ModifiedDateTime = a.ModifiedDateTime,
                                      ModifiedBy = a.ModifiedBy,
                                      ModifiedMachine = a.ModifiedMachine,
                                      BookName = b.DescriptionEnglish,
                                      MemberName = c.FirstName + " " + c.Surname,
                                      IsPrimaryKeyExist = false,
                                    }).ToList();

          return lstLendingDetailsModel;

        }


      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }
  }
}
