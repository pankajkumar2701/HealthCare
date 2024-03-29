using Microsoft.EntityFrameworkCore;
using HealthCare.Entities;

namespace HealthCare.Data
{
    public class HealthCareContext : DbContext
    {
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=;Initial Catalog=;Persist Security Info=True;user id=;password=;Integrated Security=false;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().HasKey(a => a.Id);
            modelBuilder.Entity<UserToken>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleEntitlement>().HasKey(a => a.Id);
            modelBuilder.Entity<Entity>().HasKey(a => a.Id);
            modelBuilder.Entity<Tenant>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<Patient>().HasKey(a => a.Id);
            modelBuilder.Entity<Gender>().HasKey(a => a.Id);
            modelBuilder.Entity<Title>().HasKey(a => a.Id);
            modelBuilder.Entity<Address>().HasKey(a => a.Id);
            modelBuilder.Entity<Country>().HasKey(a => a.Id);
            modelBuilder.Entity<Language>().HasKey(a => a.Id);
            modelBuilder.Entity<Currency>().HasKey(a => a.Id);
            modelBuilder.Entity<Location>().HasKey(a => a.Id);
            modelBuilder.Entity<Membership>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientNotes>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientAllergy>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientStatistics>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientComorbidity>().HasKey(a => a.Id);
            modelBuilder.Entity<Comorbidity>().HasKey(a => a.Id);
            modelBuilder.Entity<ContactMember>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientPayor>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientLifeStyle>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientEnrollmentLink>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<PregnancyHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientMedicalHistoryNote>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientPregnancy>().HasKey(a => a.Id);
            modelBuilder.Entity<Visit>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMedicalCertificate>().HasKey(a => a.Id);
            modelBuilder.Entity<Invoice>().HasKey(a => a.Id);
            modelBuilder.Entity<InvoiceLine>().HasKey(a => a.Id);
            modelBuilder.Entity<InvoiceFile>().HasKey(a => a.Id);
            modelBuilder.Entity<Dispense>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseItem>().HasKey(a => a.Id);
            modelBuilder.Entity<PatientPharmacyQueue>().HasKey(a => a.Id);
            modelBuilder.Entity<DispenseItemDosage>().HasKey(a => a.Id);
            modelBuilder.Entity<PaymentGateway>().HasKey(a => a.Id);
            modelBuilder.Entity<Notification>().HasKey(a => a.Id);
            modelBuilder.Entity<AppointmentReminderLog>().HasKey(a => a.Id);
            modelBuilder.Entity<AccountSettlement>().HasKey(a => a.Id);
            modelBuilder.Entity<AppointmentService>().HasKey(a => a.Id);
            modelBuilder.Entity<Payment>().HasKey(a => a.Id);
            modelBuilder.Entity<PaymentMode>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitInvestigation>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorInvestigation>().HasKey(a => a.Id);
            modelBuilder.Entity<Investigation>().HasKey(a => a.Id);
            modelBuilder.Entity<Product>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductBatch>().HasKey(a => a.Id);
            modelBuilder.Entity<FinanceSetting>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductUom>().HasKey(a => a.Id);
            modelBuilder.Entity<GstSettings>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductClassification>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductManufacture>().HasKey(a => a.Id);
            modelBuilder.Entity<Formulation>().HasKey(a => a.Id);
            modelBuilder.Entity<Medication>().HasKey(a => a.Id);
            modelBuilder.Entity<DrugListItems>().HasKey(a => a.Id);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationComposition>().HasKey(a => a.Id);
            modelBuilder.Entity<Generic>().HasKey(a => a.Id);
            modelBuilder.Entity<MedicationDosage>().HasKey(a => a.Id);
            modelBuilder.Entity<Route>().HasKey(a => a.Id);
            modelBuilder.Entity<Procedure>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductCategory>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitVitalTemplateParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitGuideline>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitDiagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<Diagnosis>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitType>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitMode>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitChiefComplaint>().HasKey(a => a.Id);
            modelBuilder.Entity<ChiefComplaint>().HasKey(a => a.Id);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<ClinicalParameterValue>().HasKey(a => a.Id);
            modelBuilder.Entity<Uom>().HasKey(a => a.Id);
            modelBuilder.Entity<Doctor>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<TokenManagement>().HasKey(a => a.Id);
            modelBuilder.Entity<DayVisit>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceipt>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptFile>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptActivityHistory>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReceiptItem>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturn>().HasKey(a => a.Id);
            modelBuilder.Entity<SubReason>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnItem>().HasKey(a => a.Id);
            modelBuilder.Entity<GoodsReturnFile>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceList>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListVersion>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListItem>().HasKey(a => a.Id);
            modelBuilder.Entity<PriceListComponent>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrder>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderLine>().HasKey(a => a.Id);
            modelBuilder.Entity<PurchaseOrderFile>().HasKey(a => a.Id);
            modelBuilder.Entity<Requisition>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionLine>().HasKey(a => a.Id);
            modelBuilder.Entity<RequisitionFile>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustment>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentItem>().HasKey(a => a.Id);
            modelBuilder.Entity<StockAdjustmentFile>().HasKey(a => a.Id);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.Tenant).WithMany(b => b.UserInRole).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.Role).WithMany(b => b.UserInRole).HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.User).WithMany(b => b.UserInRole).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.CreatedByUser).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UserToken>().HasOne(a => a.Tenant).WithMany(b => b.UserToken).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserToken>().HasOne(a => a.User).WithMany(b => b.UserToken).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.Tenant).WithMany(b => b.RoleEntitlement).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.Role).WithMany(b => b.RoleEntitlement).HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.Entity).WithMany(b => b.RoleEntitlement).HasForeignKey(c => c.EntityId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.CreatedByUser).WithMany(b => b.RoleEntitlement).HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.Tenant).WithMany(b => b.Entity).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entity>().HasOne(a => a.CreatedByUser).WithMany(b => b.Entity).HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<User>().HasOne(a => a.Tenant).WithMany(b => b.User).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.Tenant).WithMany(b => b.Role).HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.CreatedByUser).WithMany(b => b.Role).HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Role>().HasOne(a => a.UpdatedByUser).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Patient>().HasOne(a => a.Title).WithMany(b => b.Patient).HasForeignKey(c => c.TitleId);
            modelBuilder.Entity<Patient>().HasOne(a => a.Gender).WithMany(b => b.Patient).HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<Patient>().HasOne(a => a.Address).WithMany(b => b.Patient).HasForeignKey(c => c.AddressId);
            modelBuilder.Entity<Patient>().HasOne(a => a.Location).WithMany(b => b.Patient).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientNotesPatientNotes).WithMany(b => b.Patient).HasForeignKey(c => c.PatientNotes);
            modelBuilder.Entity<Patient>().HasOne(a => a.Membership).WithMany(b => b.Patient).HasForeignKey(c => c.MembershipId);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientAllergyPatientAllergy).WithMany(b => b.Patient).HasForeignKey(c => c.PatientAllergy);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientStatisticsPatientStatistics).WithMany(b => b.Patient).HasForeignKey(c => c.PatientStatistics);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientCategoriesPatientCategory).WithMany(b => b.Patient).HasForeignKey(c => c.PatientCategories);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientComorbiditiesPatientComorbidity).WithMany(b => b.Patient).HasForeignKey(c => c.PatientComorbidities);
            modelBuilder.Entity<Patient>().HasOne(a => a.ContactMembersContactMember).WithMany(b => b.Patient).HasForeignKey(c => c.ContactMembers);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientPayorsPatientPayor).WithMany(b => b.Patient).HasForeignKey(c => c.PatientPayors);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientLifeStylePatientLifeStyle).WithMany(b => b.Patient).HasForeignKey(c => c.PatientLifeStyle);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientEnrollmentLinksPatientEnrollmentLink).WithMany(b => b.Patient).HasForeignKey(c => c.PatientEnrollmentLinks);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientHospitalisationHistoriesPatientHospitalisationHistory).WithMany(b => b.Patient).HasForeignKey(c => c.PatientHospitalisationHistories);
            modelBuilder.Entity<Patient>().HasOne(a => a.PregnancyHistoriesPregnancyHistory).WithMany(b => b.Patient).HasForeignKey(c => c.PregnancyHistories);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientMedicalHistoryNotesPatientMedicalHistoryNote).WithMany(b => b.Patient).HasForeignKey(c => c.PatientMedicalHistoryNotes);
            modelBuilder.Entity<Patient>().HasOne(a => a.PatientPregnanciesPatientPregnancy).WithMany(b => b.Patient).HasForeignKey(c => c.PatientPregnancies);
            modelBuilder.Entity<Address>().HasOne(a => a.Country).WithMany(b => b.Address).HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<Country>().HasOne(a => a.Currency).WithMany(b => b.Country).HasForeignKey(c => c.CurrencyId);
            modelBuilder.Entity<Country>().HasOne(a => a.Language).WithMany(b => b.Country).HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<Location>().HasOne(a => a.Country).WithMany(b => b.Location).HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<PatientNotes>().HasOne(a => a.Patient).WithMany(b => b.PatientNotes).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientAllergy>().HasOne(a => a.Patient).WithMany(b => b.PatientAllergy).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientStatistics>().HasOne(a => a.Patient).WithMany(b => b.PatientStatistics).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientCategory>().HasOne(a => a.Patient).WithMany(b => b.PatientCategory).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.Comorbidity).WithMany(b => b.PatientComorbidity).HasForeignKey(c => c.ComorbidityId);
            modelBuilder.Entity<PatientComorbidity>().HasOne(a => a.Patient).WithMany(b => b.PatientComorbidity).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.Patient).WithMany(b => b.ContactMember).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.Title).WithMany(b => b.ContactMember).HasForeignKey(c => c.TitleId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.Gender).WithMany(b => b.ContactMember).HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.Country).WithMany(b => b.ContactMember).HasForeignKey(c => c.CountryId);
            modelBuilder.Entity<ContactMember>().HasOne(a => a.Location).WithMany(b => b.ContactMember).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.Patient).WithMany(b => b.PatientPayor).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientPayor>().HasOne(a => a.ContactMember).WithMany(b => b.PatientPayor).HasForeignKey(c => c.ContactMemberId);
            modelBuilder.Entity<PatientLifeStyle>().HasOne(a => a.Patient).WithMany(b => b.PatientLifeStyle).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientEnrollmentLink>().HasOne(a => a.Patient).WithMany(b => b.PatientEnrollmentLink).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientHospitalisationHistory>().HasOne(a => a.Patient).WithMany(b => b.PatientHospitalisationHistory).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PregnancyHistory>().HasOne(a => a.Patient).WithMany(b => b.PregnancyHistory).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientMedicalHistoryNote>().HasOne(a => a.Patient).WithMany(b => b.PatientMedicalHistoryNote).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientPregnancy>().HasOne(a => a.Patient).WithMany(b => b.PatientPregnancy).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Visit>().HasOne(a => a.Patient).WithMany(b => b.Visit).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Visit>().HasOne(a => a.Location).WithMany(b => b.Visit).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitTypeVisitType).WithMany(b => b.Visit).HasForeignKey(c => c.VisitType);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitModeVisitMode).WithMany(b => b.Visit).HasForeignKey(c => c.VisitMode);
            modelBuilder.Entity<Visit>().HasOne(a => a.PatientPatient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<Visit>().HasOne(a => a.DoctorDoctor).WithMany(b => b.Visit).HasForeignKey(c => c.Doctor);
            modelBuilder.Entity<Visit>().HasOne(a => a.LocationLocation).WithMany().HasForeignKey(c => c.Location);
            modelBuilder.Entity<Visit>().HasOne(a => a.ContactAddress).WithMany(b => b.Visit).HasForeignKey(c => c.Contact);
            modelBuilder.Entity<Visit>().HasOne(a => a.AppointmentAppointment).WithMany(b => b.Visit).HasForeignKey(c => c.Appointment);
            modelBuilder.Entity<Visit>().HasOne(a => a.DayVisitDayVisit).WithMany(b => b.Visit).HasForeignKey(c => c.DayVisit);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitChiefComplaintVisitChiefComplaint).WithMany(b => b.Visit).HasForeignKey(c => c.VisitChiefComplaint);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitDiagnosisVisitDiagnosis).WithMany(b => b.Visit).HasForeignKey(c => c.VisitDiagnosis);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitGuidelineVisitGuideline).WithMany(b => b.Visit).HasForeignKey(c => c.VisitGuideline);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitVitalTemplateParameterVisitVitalTemplateParameter).WithMany(b => b.Visit).HasForeignKey(c => c.VisitVitalTemplateParameter);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitInvestigationVisitInvestigation).WithMany(b => b.Visit).HasForeignKey(c => c.VisitInvestigation);
            modelBuilder.Entity<Visit>().HasOne(a => a.InvoiceInvoice).WithMany(b => b.Visit).HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<Visit>().HasOne(a => a.DispensesDispense).WithMany(b => b.Visit).HasForeignKey(c => c.Dispenses);
            modelBuilder.Entity<Visit>().HasOne(a => a.VisitMedicalCertificatesVisitMedicalCertificate).WithMany(b => b.Visit).HasForeignKey(c => c.VisitMedicalCertificates);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.Patient).WithMany(b => b.VisitMedicalCertificate).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.Visit).WithMany(b => b.VisitMedicalCertificate).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.Product).WithMany(b => b.VisitMedicalCertificate).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<VisitMedicalCertificate>().HasOne(a => a.InvoiceLine).WithMany(b => b.VisitMedicalCertificate).HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.Visit).WithMany(b => b.Invoice).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.Patient).WithMany(b => b.Invoice).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.Doctor).WithMany(b => b.Invoice).HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.Location).WithMany(b => b.Invoice).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.PaymentPayment).WithMany(b => b.Invoice).HasForeignKey(c => c.Payment);
            modelBuilder.Entity<Invoice>().HasOne(a => a.AppointmentAppointment).WithMany(b => b.Invoice).HasForeignKey(c => c.Appointment);
            modelBuilder.Entity<Invoice>().HasOne(a => a.DayVisitDayVisit).WithMany(b => b.Invoice).HasForeignKey(c => c.DayVisit);
            modelBuilder.Entity<Invoice>().HasOne(a => a.ReferredByIdAddress).WithMany(b => b.Invoice).HasForeignKey(c => c.ReferredById);
            modelBuilder.Entity<Invoice>().HasOne(a => a.InvoiceFilesInvoiceFile).WithMany(b => b.Invoice).HasForeignKey(c => c.InvoiceFiles);
            modelBuilder.Entity<Invoice>().HasOne(a => a.PayorIdAddress).WithMany().HasForeignKey(c => c.PayorId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.InvoiceLine).WithMany(b => b.Invoice).HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<Invoice>().HasOne(a => a.DispenseDispense).WithMany(b => b.Invoice).HasForeignKey(c => c.Dispense);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.Invoice).WithMany(b => b.InvoiceLine).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.Product).WithMany(b => b.InvoiceLine).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.ProductBatch).WithMany(b => b.InvoiceLine).HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.ProductUom).WithMany(b => b.InvoiceLine).HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<InvoiceLine>().HasOne(a => a.GstSettings).WithMany(b => b.InvoiceLine).HasForeignKey(c => c.GstSettingsId);
            modelBuilder.Entity<InvoiceFile>().HasOne(a => a.Invoice).WithMany(b => b.InvoiceFile).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.Patient).WithMany(b => b.Dispense).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.Visit).WithMany(b => b.Dispense).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.Invoice).WithMany(b => b.Dispense).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.Location).WithMany(b => b.Dispense).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Dispense>().HasOne(a => a.LocationLocation).WithMany().HasForeignKey(c => c.Location);
            modelBuilder.Entity<Dispense>().HasOne(a => a.DispenseActivityHistoryDispenseActivityHistory).WithMany(b => b.Dispense).HasForeignKey(c => c.DispenseActivityHistory);
            modelBuilder.Entity<Dispense>().HasOne(a => a.DispenseItemsDispenseItem).WithMany(b => b.Dispense).HasForeignKey(c => c.DispenseItems);
            modelBuilder.Entity<Dispense>().HasOne(a => a.PatientPharmacyQueuesPatientPharmacyQueue).WithMany(b => b.Dispense).HasForeignKey(c => c.PatientPharmacyQueues);
            modelBuilder.Entity<DispenseActivityHistory>().HasOne(a => a.Dispense).WithMany(b => b.DispenseActivityHistory).HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.Dispense).WithMany(b => b.DispenseItem).HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.Product).WithMany(b => b.DispenseItem).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.ProductBatch).WithMany(b => b.DispenseItem).HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<DispenseItem>().HasOne(a => a.DispenseItemDosageDispenseItemDosage).WithMany(b => b.DispenseItem).HasForeignKey(c => c.DispenseItemDosage);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.Patient).WithMany(b => b.PatientPharmacyQueue).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.Visit).WithMany(b => b.PatientPharmacyQueue).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<PatientPharmacyQueue>().HasOne(a => a.Dispense).WithMany(b => b.PatientPharmacyQueue).HasForeignKey(c => c.DispenseId);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.DispenseItem).WithMany(b => b.DispenseItemDosage).HasForeignKey(c => c.DispenseItemId);
            modelBuilder.Entity<DispenseItemDosage>().HasOne(a => a.Uom).WithMany(b => b.DispenseItemDosage).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.Appointment).WithMany(b => b.PaymentGateway).HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.Doctor).WithMany(b => b.PaymentGateway).HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.Patient).WithMany(b => b.PaymentGateway).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<PaymentGateway>().HasOne(a => a.Invoice).WithMany(b => b.PaymentGateway).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<Notification>().HasOne(a => a.Appointment).WithMany(b => b.Notification).HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<Notification>().HasOne(a => a.AppointmentAppointment).WithMany().HasForeignKey(c => c.Appointment);
            modelBuilder.Entity<AppointmentReminderLog>().HasOne(a => a.Appointment).WithMany(b => b.AppointmentReminderLog).HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<AppointmentReminderLog>().HasOne(a => a.AppointmentAppointment).WithMany().HasForeignKey(c => c.Appointment);
            modelBuilder.Entity<AccountSettlement>().HasOne(a => a.Appointment).WithMany(b => b.AccountSettlement).HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<AccountSettlement>().HasOne(a => a.Invoice).WithMany(b => b.AccountSettlement).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<AccountSettlement>().HasOne(a => a.CurrencyCurrency).WithMany(b => b.AccountSettlement).HasForeignKey(c => c.Currency);
            modelBuilder.Entity<AppointmentService>().HasOne(a => a.Appointment).WithMany(b => b.AppointmentService).HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<AppointmentService>().HasOne(a => a.ServiceProduct).WithMany(b => b.AppointmentService).HasForeignKey(c => c.Service);
            modelBuilder.Entity<Payment>().HasOne(a => a.Patient).WithMany(b => b.Payment).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Payment>().HasOne(a => a.Invoice).WithMany(b => b.Payment).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<Payment>().HasOne(a => a.PaymentMode).WithMany(b => b.Payment).HasForeignKey(c => c.PaymentModeId);
            modelBuilder.Entity<Payment>().HasOne(a => a.Location).WithMany(b => b.Payment).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.DoctorInvestigation).WithMany(b => b.VisitInvestigation).HasForeignKey(c => c.DoctorInvestigationId);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.Patient).WithMany(b => b.VisitInvestigation).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<VisitInvestigation>().HasOne(a => a.InvoiceLine).WithMany(b => b.VisitInvestigation).HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<DoctorInvestigation>().HasOne(a => a.Investigation).WithMany(b => b.DoctorInvestigation).HasForeignKey(c => c.InvestigationId);
            modelBuilder.Entity<DoctorInvestigation>().HasOne(a => a.Doctor).WithMany(b => b.DoctorInvestigation).HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<Investigation>().HasOne(a => a.Product).WithMany(b => b.Investigation).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductCategory).WithMany(b => b.Product).HasForeignKey(c => c.ProductCategoryId);
            modelBuilder.Entity<Product>().HasOne(a => a.Medication).WithMany(b => b.Product).HasForeignKey(c => c.MedicationId);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductCategoryProductCategory).WithMany().HasForeignKey(c => c.ProductCategory);
            modelBuilder.Entity<Product>().HasOne(a => a.InvestigationInvestigation).WithMany(b => b.Product).HasForeignKey(c => c.Investigation);
            modelBuilder.Entity<Product>().HasOne(a => a.ProcedureProcedure).WithMany(b => b.Product).HasForeignKey(c => c.Procedure);
            modelBuilder.Entity<Product>().HasOne(a => a.ContactAddress).WithMany(b => b.Product).HasForeignKey(c => c.Contact);
            modelBuilder.Entity<Product>().HasOne(a => a.MedicationMedication).WithMany().HasForeignKey(c => c.Medication);
            modelBuilder.Entity<Product>().HasOne(a => a.FormulationFormulation).WithMany(b => b.Product).HasForeignKey(c => c.Formulation);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductManufactureProductManufacture).WithMany(b => b.Product).HasForeignKey(c => c.ProductManufacture);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductClassificationProductClassification).WithMany(b => b.Product).HasForeignKey(c => c.ProductClassification);
            modelBuilder.Entity<Product>().HasOne(a => a.UomUom).WithMany(b => b.Product).HasForeignKey(c => c.Uom);
            modelBuilder.Entity<Product>().HasOne(a => a.GstSettingsGstSettings).WithMany(b => b.Product).HasForeignKey(c => c.GstSettings);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductUomsProductUom).WithMany(b => b.Product).HasForeignKey(c => c.ProductUoms);
            modelBuilder.Entity<Product>().HasOne(a => a.FinanceSettingsFinanceSetting).WithMany(b => b.Product).HasForeignKey(c => c.FinanceSettings);
            modelBuilder.Entity<Product>().HasOne(a => a.ProductBatchProductBatch).WithMany(b => b.Product).HasForeignKey(c => c.ProductBatch);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.ProductUom).WithMany(b => b.ProductBatch).HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.LocationLocation).WithMany(b => b.ProductBatch).HasForeignKey(c => c.Location);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.ProductProduct).WithMany(b => b.ProductBatch).HasForeignKey(c => c.Product);
            modelBuilder.Entity<ProductBatch>().HasOne(a => a.InvoiceLine).WithMany(b => b.ProductBatch).HasForeignKey(c => c.InvoiceLineId);
            modelBuilder.Entity<FinanceSetting>().HasOne(a => a.Product).WithMany(b => b.FinanceSetting).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductUom>().HasOne(a => a.Product).WithMany(b => b.ProductUom).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<ProductUom>().HasOne(a => a.Uom).WithMany(b => b.ProductUom).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<ProductClassification>().HasOne(a => a.ProductsProduct).WithMany(b => b.ProductClassification).HasForeignKey(c => c.Products);
            modelBuilder.Entity<ProductManufacture>().HasOne(a => a.ProductsProduct).WithMany(b => b.ProductManufacture).HasForeignKey(c => c.Products);
            modelBuilder.Entity<Medication>().HasOne(a => a.Route).WithMany(b => b.Medication).HasForeignKey(c => c.RouteId);
            modelBuilder.Entity<Medication>().HasOne(a => a.MedicationDosagesMedicationDosage).WithMany(b => b.Medication).HasForeignKey(c => c.MedicationDosages);
            modelBuilder.Entity<Medication>().HasOne(a => a.MedicationCompositionsMedicationComposition).WithMany(b => b.Medication).HasForeignKey(c => c.MedicationCompositions);
            modelBuilder.Entity<Medication>().HasOne(a => a.DoctorFavouriteMedicationDoctorFavouriteMedication).WithMany(b => b.Medication).HasForeignKey(c => c.DoctorFavouriteMedication);
            modelBuilder.Entity<Medication>().HasOne(a => a.ProductProduct).WithMany(b => b.Medication).HasForeignKey(c => c.Product);
            modelBuilder.Entity<Medication>().HasOne(a => a.DrugListItemsDrugListItems).WithMany(b => b.Medication).HasForeignKey(c => c.DrugListItems);
            modelBuilder.Entity<DrugListItems>().HasOne(a => a.Medication).WithMany(b => b.DrugListItems).HasForeignKey(c => c.MedicationId);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasOne(a => a.Medication).WithMany(b => b.DoctorFavouriteMedication).HasForeignKey(c => c.MedicationId);
            modelBuilder.Entity<DoctorFavouriteMedication>().HasOne(a => a.Doctor).WithMany(b => b.DoctorFavouriteMedication).HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.Medication).WithMany(b => b.MedicationComposition).HasForeignKey(c => c.MedicationId);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.Generic).WithMany(b => b.MedicationComposition).HasForeignKey(c => c.GenericId);
            modelBuilder.Entity<MedicationComposition>().HasOne(a => a.Uom).WithMany(b => b.MedicationComposition).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.Medication).WithMany(b => b.MedicationDosage).HasForeignKey(c => c.MedicationId);
            modelBuilder.Entity<MedicationDosage>().HasOne(a => a.Uom).WithMany(b => b.MedicationDosage).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<Procedure>().HasOne(a => a.Product).WithMany(b => b.Procedure).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<VisitVitalTemplateParameter>().HasOne(a => a.Visit).WithMany(b => b.VisitVitalTemplateParameter).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitVitalTemplateParameter>().HasOne(a => a.ClinicalParameter).WithMany(b => b.VisitVitalTemplateParameter).HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<VisitVitalTemplateParameter>().HasOne(a => a.ClinicalParameterValue).WithMany(b => b.VisitVitalTemplateParameter).HasForeignKey(c => c.ClinicalParameterValueId);
            modelBuilder.Entity<VisitVitalTemplateParameter>().HasOne(a => a.Uom).WithMany(b => b.VisitVitalTemplateParameter).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<VisitGuideline>().HasOne(a => a.Visit).WithMany(b => b.VisitGuideline).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitGuideline>().HasOne(a => a.Patient).WithMany(b => b.VisitGuideline).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.Diagnosis).WithMany(b => b.VisitDiagnosis).HasForeignKey(c => c.DiagnosisId);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.Visit).WithMany(b => b.VisitDiagnosis).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitDiagnosis>().HasOne(a => a.VisitDiagnosisParameterVisitDiagnosisParameter).WithMany(b => b.VisitDiagnosis).HasForeignKey(c => c.VisitDiagnosisParameter);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.VisitDiagnosis).WithMany(b => b.VisitDiagnosisParameter).HasForeignKey(c => c.VisitDiagnosisId);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.ClinicalParameter).WithMany(b => b.VisitDiagnosisParameter).HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.ClinicalParameterValue).WithMany(b => b.VisitDiagnosisParameter).HasForeignKey(c => c.ClinicalParameterValueId);
            modelBuilder.Entity<VisitDiagnosisParameter>().HasOne(a => a.Uom).WithMany(b => b.VisitDiagnosisParameter).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<VisitChiefComplaint>().HasOne(a => a.ChiefComplaint).WithMany(b => b.VisitChiefComplaint).HasForeignKey(c => c.ChiefComplaintId);
            modelBuilder.Entity<VisitChiefComplaint>().HasOne(a => a.Visit).WithMany(b => b.VisitChiefComplaint).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.ClinicalParameter).WithMany(b => b.VisitChiefComplaintParameter).HasForeignKey(c => c.ClinicalParameterId);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.ClinicalParameterValue).WithMany(b => b.VisitChiefComplaintParameter).HasForeignKey(c => c.ClinicalParameterValueId);
            modelBuilder.Entity<VisitChiefComplaintParameter>().HasOne(a => a.Uom).WithMany(b => b.VisitChiefComplaintParameter).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<ClinicalParameter>().HasOne(a => a.Uom).WithMany(b => b.ClinicalParameter).HasForeignKey(c => c.UomId);
            modelBuilder.Entity<Doctor>().HasOne(a => a.Title).WithMany(b => b.Doctor).HasForeignKey(c => c.TitleId);
            modelBuilder.Entity<Doctor>().HasOne(a => a.OfficialAddressIdAddress).WithMany(b => b.Doctor).HasForeignKey(c => c.OfficialAddressId);
            modelBuilder.Entity<Doctor>().HasOne(a => a.Language).WithMany(b => b.Doctor).HasForeignKey(c => c.LanguageId);
            modelBuilder.Entity<Doctor>().HasOne(a => a.Gender).WithMany(b => b.Doctor).HasForeignKey(c => c.GenderId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(b => b.Appointment).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Invoice).WithMany(b => b.Appointment).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Visit).WithMany(b => b.Appointment).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Location).WithMany(b => b.Appointment).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.PatientPatient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<Appointment>().HasOne(a => a.InvoiceInvoice).WithMany().HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<Appointment>().HasOne(a => a.VisitVisit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<Appointment>().HasOne(a => a.AppointmentServicesAppointmentService).WithMany(b => b.Appointment).HasForeignKey(c => c.AppointmentServices);
            modelBuilder.Entity<Appointment>().HasOne(a => a.AccountSettlementsAccountSettlement).WithMany(b => b.Appointment).HasForeignKey(c => c.AccountSettlements);
            modelBuilder.Entity<Appointment>().HasOne(a => a.AppointmentReminderLogsAppointmentReminderLog).WithMany(b => b.Appointment).HasForeignKey(c => c.AppointmentReminderLogs);
            modelBuilder.Entity<Appointment>().HasOne(a => a.DayVisitsDayVisit).WithMany(b => b.Appointment).HasForeignKey(c => c.DayVisits);
            modelBuilder.Entity<Appointment>().HasOne(a => a.NotificationsNotification).WithMany(b => b.Appointment).HasForeignKey(c => c.Notifications);
            modelBuilder.Entity<Appointment>().HasOne(a => a.PaymentGatewaysPaymentGateway).WithMany(b => b.Appointment).HasForeignKey(c => c.PaymentGateways);
            modelBuilder.Entity<Appointment>().HasOne(a => a.TokenManagementTokenManagement).WithMany(b => b.Appointment).HasForeignKey(c => c.TokenManagement);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.Patient).WithMany(b => b.TokenManagement).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.Doctor).WithMany(b => b.TokenManagement).HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.Location).WithMany(b => b.TokenManagement).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<TokenManagement>().HasOne(a => a.DayVisit).WithMany(b => b.TokenManagement).HasForeignKey(c => c.DayVisitId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.Patient).WithMany(b => b.DayVisit).HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.Doctor).WithMany(b => b.DayVisit).HasForeignKey(c => c.DoctorId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.Visit).WithMany(b => b.DayVisit).HasForeignKey(c => c.VisitId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.Appointment).WithMany(b => b.DayVisit).HasForeignKey(c => c.AppointmentId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.Invoice).WithMany(b => b.DayVisit).HasForeignKey(c => c.InvoiceId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.Location).WithMany(b => b.DayVisit).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.PatientPatient).WithMany().HasForeignKey(c => c.Patient);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.DoctorDoctor).WithMany().HasForeignKey(c => c.Doctor);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.VisitVisit).WithMany().HasForeignKey(c => c.Visit);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.AppointmentAppointment).WithMany().HasForeignKey(c => c.Appointment);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.InvoiceInvoice).WithMany().HasForeignKey(c => c.Invoice);
            modelBuilder.Entity<DayVisit>().HasOne(a => a.LocationLocation).WithMany().HasForeignKey(c => c.Location);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.Location).WithMany(b => b.GoodsReceipt).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.GoodsReceiptItemGoodsReceiptItem).WithMany(b => b.GoodsReceipt).HasForeignKey(c => c.GoodsReceiptItem);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.GoodsReturnsGoodsReturn).WithMany(b => b.GoodsReceipt).HasForeignKey(c => c.GoodsReturns);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.GoodsReceiptActivityHistoryGoodsReceiptActivityHistory).WithMany(b => b.GoodsReceipt).HasForeignKey(c => c.GoodsReceiptActivityHistory);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.GoodsReceiptFileGoodsReceiptFile).WithMany(b => b.GoodsReceipt).HasForeignKey(c => c.GoodsReceiptFile);
            modelBuilder.Entity<GoodsReceipt>().HasOne(a => a.GoodsReceiptPurchaseOrderRelationGoodsReceiptPurchaseOrderRelation).WithMany(b => b.GoodsReceipt).HasForeignKey(c => c.GoodsReceiptPurchaseOrderRelation);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasOne(a => a.GoodsReceipt).WithMany(b => b.GoodsReceiptPurchaseOrderRelation).HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptPurchaseOrderRelation>().HasOne(a => a.PurchaseOrder).WithMany(b => b.GoodsReceiptPurchaseOrderRelation).HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<GoodsReceiptFile>().HasOne(a => a.GoodsReceipt).WithMany(b => b.GoodsReceiptFile).HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptActivityHistory>().HasOne(a => a.GoodsReceipt).WithMany(b => b.GoodsReceiptActivityHistory).HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.GoodsReceipt).WithMany(b => b.GoodsReceiptItem).HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.Product).WithMany(b => b.GoodsReceiptItem).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.ProductBatch).WithMany(b => b.GoodsReceiptItem).HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.PurchaseOrder).WithMany(b => b.GoodsReceiptItem).HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<GoodsReceiptItem>().HasOne(a => a.PurchaseOrderLine).WithMany(b => b.GoodsReceiptItem).HasForeignKey(c => c.PurchaseOrderLineId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.GoodsReceipt).WithMany(b => b.GoodsReturn).HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.Location).WithMany(b => b.GoodsReturn).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.GoodsReturnFileGoodsReturnFile).WithMany(b => b.GoodsReturn).HasForeignKey(c => c.GoodsReturnFile);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.GoodsReturnItemGoodsReturnItem).WithMany(b => b.GoodsReturn).HasForeignKey(c => c.GoodsReturnItem);
            modelBuilder.Entity<GoodsReturn>().HasOne(a => a.SubReasonSubReason).WithMany(b => b.GoodsReturn).HasForeignKey(c => c.SubReason);
            modelBuilder.Entity<SubReason>().HasOne(a => a.GoodsReturnsGoodsReturn).WithMany(b => b.SubReason).HasForeignKey(c => c.GoodsReturns);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.GoodsReturn).WithMany(b => b.GoodsReturnItem).HasForeignKey(c => c.GoodsReturnId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.Product).WithMany(b => b.GoodsReturnItem).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.ProductBatch).WithMany(b => b.GoodsReturnItem).HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.GoodsReceiptItem).WithMany(b => b.GoodsReturnItem).HasForeignKey(c => c.GoodsReceiptItemId);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.ProductUomProductUom).WithMany(b => b.GoodsReturnItem).HasForeignKey(c => c.ProductUom);
            modelBuilder.Entity<GoodsReturnItem>().HasOne(a => a.SubReasonSubReason).WithMany(b => b.GoodsReturnItem).HasForeignKey(c => c.SubReason);
            modelBuilder.Entity<GoodsReturnFile>().HasOne(a => a.GoodsReturn).WithMany(b => b.GoodsReturnFile).HasForeignKey(c => c.GoodsReturnId);
            modelBuilder.Entity<PriceList>().HasOne(a => a.PriceListComponentsPriceListComponent).WithMany(b => b.PriceList).HasForeignKey(c => c.PriceListComponents);
            modelBuilder.Entity<PriceList>().HasOne(a => a.PriceListItemsPriceListItem).WithMany(b => b.PriceList).HasForeignKey(c => c.PriceListItems);
            modelBuilder.Entity<PriceList>().HasOne(a => a.PriceListVersionsPriceListVersion).WithMany(b => b.PriceList).HasForeignKey(c => c.PriceListVersions);
            modelBuilder.Entity<PriceListVersion>().HasOne(a => a.PriceList).WithMany(b => b.PriceListVersion).HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.PriceList).WithMany(b => b.PriceListItem).HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.Product).WithMany(b => b.PriceListItem).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PriceListItem>().HasOne(a => a.ProductUom).WithMany(b => b.PriceListItem).HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.PriceList).WithMany(b => b.PriceListComponent).HasForeignKey(c => c.PriceListId);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.LocationLocation).WithMany(b => b.PriceListComponent).HasForeignKey(c => c.Location);
            modelBuilder.Entity<PriceListComponent>().HasOne(a => a.Membership).WithMany(b => b.PriceListComponent).HasForeignKey(c => c.MembershipId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.Location).WithMany(b => b.PurchaseOrder).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.PurchaseOrderFilePurchaseOrderFile).WithMany(b => b.PurchaseOrder).HasForeignKey(c => c.PurchaseOrderFile);
            modelBuilder.Entity<PurchaseOrder>().HasOne(a => a.RequisitionRequisition).WithMany(b => b.PurchaseOrder).HasForeignKey(c => c.Requisition);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.PurchaseOrder).WithMany(b => b.PurchaseOrderLine).HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.Product).WithMany(b => b.PurchaseOrderLine).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.ProductUom).WithMany(b => b.PurchaseOrderLine).HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.Requisition).WithMany(b => b.PurchaseOrderLine).HasForeignKey(c => c.RequisitionId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.RequisitionLine).WithMany(b => b.PurchaseOrderLine).HasForeignKey(c => c.RequisitionLineId);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(a => a.GoodsReceipt).WithMany(b => b.PurchaseOrderLine).HasForeignKey(c => c.GoodsReceiptId);
            modelBuilder.Entity<PurchaseOrderFile>().HasOne(a => a.PurchaseOrder).WithMany(b => b.PurchaseOrderFile).HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<Requisition>().HasOne(a => a.Location).WithMany(b => b.Requisition).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<Requisition>().HasOne(a => a.RequisitionFileRequisitionFile).WithMany(b => b.Requisition).HasForeignKey(c => c.RequisitionFile);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.Requisition).WithMany(b => b.RequisitionLine).HasForeignKey(c => c.RequisitionId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.Product).WithMany(b => b.RequisitionLine).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.ProductUom).WithMany(b => b.RequisitionLine).HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.PurchaseOrder).WithMany(b => b.RequisitionLine).HasForeignKey(c => c.PurchaseOrderId);
            modelBuilder.Entity<RequisitionLine>().HasOne(a => a.PurchaseOrderLine).WithMany(b => b.RequisitionLine).HasForeignKey(c => c.PurchaseOrderLineId);
            modelBuilder.Entity<RequisitionFile>().HasOne(a => a.Requisition).WithMany(b => b.RequisitionFile).HasForeignKey(c => c.RequisitionId);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.Location).WithMany(b => b.StockAdjustment).HasForeignKey(c => c.LocationId);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.StockAdjustmentItemStockAdjustmentItem).WithMany(b => b.StockAdjustment).HasForeignKey(c => c.StockAdjustmentItem);
            modelBuilder.Entity<StockAdjustment>().HasOne(a => a.StockAdjustmentFileStockAdjustmentFile).WithMany(b => b.StockAdjustment).HasForeignKey(c => c.StockAdjustmentFile);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.StockAdjustment).WithMany(b => b.StockAdjustmentItem).HasForeignKey(c => c.StockAdjustmentId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.Product).WithMany(b => b.StockAdjustmentItem).HasForeignKey(c => c.ProductId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.ProductBatch).WithMany(b => b.StockAdjustmentItem).HasForeignKey(c => c.ProductBatchId);
            modelBuilder.Entity<StockAdjustmentItem>().HasOne(a => a.ProductUom).WithMany(b => b.StockAdjustmentItem).HasForeignKey(c => c.ProductUomId);
            modelBuilder.Entity<StockAdjustmentFile>().HasOne(a => a.StockAdjustment).WithMany(b => b.StockAdjustmentFile).HasForeignKey(c => c.StockAdjustmentId);
        }

        public DbSet<UserInRole> UserInRole { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<RoleEntitlement> RoleEntitlement { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<PatientNotes> PatientNotes { get; set; }
        public DbSet<PatientAllergy> PatientAllergy { get; set; }
        public DbSet<PatientStatistics> PatientStatistics { get; set; }
        public DbSet<PatientCategory> PatientCategory { get; set; }
        public DbSet<PatientComorbidity> PatientComorbidity { get; set; }
        public DbSet<Comorbidity> Comorbidity { get; set; }
        public DbSet<ContactMember> ContactMember { get; set; }
        public DbSet<PatientPayor> PatientPayor { get; set; }
        public DbSet<PatientLifeStyle> PatientLifeStyle { get; set; }
        public DbSet<PatientEnrollmentLink> PatientEnrollmentLink { get; set; }
        public DbSet<PatientHospitalisationHistory> PatientHospitalisationHistory { get; set; }
        public DbSet<PregnancyHistory> PregnancyHistory { get; set; }
        public DbSet<PatientMedicalHistoryNote> PatientMedicalHistoryNote { get; set; }
        public DbSet<PatientPregnancy> PatientPregnancy { get; set; }
        public DbSet<Visit> Visit { get; set; }
        public DbSet<VisitMedicalCertificate> VisitMedicalCertificate { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceLine> InvoiceLine { get; set; }
        public DbSet<InvoiceFile> InvoiceFile { get; set; }
        public DbSet<Dispense> Dispense { get; set; }
        public DbSet<DispenseActivityHistory> DispenseActivityHistory { get; set; }
        public DbSet<DispenseItem> DispenseItem { get; set; }
        public DbSet<PatientPharmacyQueue> PatientPharmacyQueue { get; set; }
        public DbSet<DispenseItemDosage> DispenseItemDosage { get; set; }
        public DbSet<PaymentGateway> PaymentGateway { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<AppointmentReminderLog> AppointmentReminderLog { get; set; }
        public DbSet<AccountSettlement> AccountSettlement { get; set; }
        public DbSet<AppointmentService> AppointmentService { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMode> PaymentMode { get; set; }
        public DbSet<VisitInvestigation> VisitInvestigation { get; set; }
        public DbSet<DoctorInvestigation> DoctorInvestigation { get; set; }
        public DbSet<Investigation> Investigation { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductBatch> ProductBatch { get; set; }
        public DbSet<FinanceSetting> FinanceSetting { get; set; }
        public DbSet<ProductUom> ProductUom { get; set; }
        public DbSet<GstSettings> GstSettings { get; set; }
        public DbSet<ProductClassification> ProductClassification { get; set; }
        public DbSet<ProductManufacture> ProductManufacture { get; set; }
        public DbSet<Formulation> Formulation { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<DrugListItems> DrugListItems { get; set; }
        public DbSet<DoctorFavouriteMedication> DoctorFavouriteMedication { get; set; }
        public DbSet<MedicationComposition> MedicationComposition { get; set; }
        public DbSet<Generic> Generic { get; set; }
        public DbSet<MedicationDosage> MedicationDosage { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<VisitVitalTemplateParameter> VisitVitalTemplateParameter { get; set; }
        public DbSet<VisitGuideline> VisitGuideline { get; set; }
        public DbSet<VisitDiagnosis> VisitDiagnosis { get; set; }
        public DbSet<VisitDiagnosisParameter> VisitDiagnosisParameter { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<VisitType> VisitType { get; set; }
        public DbSet<VisitMode> VisitMode { get; set; }
        public DbSet<VisitChiefComplaint> VisitChiefComplaint { get; set; }
        public DbSet<ChiefComplaint> ChiefComplaint { get; set; }
        public DbSet<VisitChiefComplaintParameter> VisitChiefComplaintParameter { get; set; }
        public DbSet<ClinicalParameter> ClinicalParameter { get; set; }
        public DbSet<ClinicalParameterValue> ClinicalParameterValue { get; set; }
        public DbSet<Uom> Uom { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<TokenManagement> TokenManagement { get; set; }
        public DbSet<DayVisit> DayVisit { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipt { get; set; }
        public DbSet<GoodsReceiptPurchaseOrderRelation> GoodsReceiptPurchaseOrderRelation { get; set; }
        public DbSet<GoodsReceiptFile> GoodsReceiptFile { get; set; }
        public DbSet<GoodsReceiptActivityHistory> GoodsReceiptActivityHistory { get; set; }
        public DbSet<GoodsReceiptItem> GoodsReceiptItem { get; set; }
        public DbSet<GoodsReturn> GoodsReturn { get; set; }
        public DbSet<SubReason> SubReason { get; set; }
        public DbSet<GoodsReturnItem> GoodsReturnItem { get; set; }
        public DbSet<GoodsReturnFile> GoodsReturnFile { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<PriceListVersion> PriceListVersion { get; set; }
        public DbSet<PriceListItem> PriceListItem { get; set; }
        public DbSet<PriceListComponent> PriceListComponent { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLine { get; set; }
        public DbSet<PurchaseOrderFile> PurchaseOrderFile { get; set; }
        public DbSet<Requisition> Requisition { get; set; }
        public DbSet<RequisitionLine> RequisitionLine { get; set; }
        public DbSet<RequisitionFile> RequisitionFile { get; set; }
        public DbSet<StockAdjustment> StockAdjustment { get; set; }
        public DbSet<StockAdjustmentItem> StockAdjustmentItem { get; set; }
        public DbSet<StockAdjustmentFile> StockAdjustmentFile { get; set; }
    }
}