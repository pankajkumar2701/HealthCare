using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HealthCare.Entities
{
    /// <summary> 
    /// Represents a medication entity with essential details
    /// </summary>
    public class Medication
    {
        /// <summary>
        /// TenantId of the Medication 
        /// </summary>
        public Guid? TenantId { get; set; }

        /// <summary>
        /// Primary key for the Medication 
        /// </summary>
        [Key]
        public Guid? Id { get; set; }

        /// <summary>
        /// Required field Name of the Medication 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// ReadyRx of the Medication 
        /// </summary>
        public bool? ReadyRx { get; set; }
        /// <summary>
        /// FormulationCode of the Medication 
        /// </summary>
        public string? FormulationCode { get; set; }
        /// <summary>
        /// OtcDrug of the Medication 
        /// </summary>
        public bool? OtcDrug { get; set; }
        /// <summary>
        /// SystemFavourite of the Medication 
        /// </summary>
        public bool? SystemFavourite { get; set; }
        /// <summary>
        /// Generic of the Medication 
        /// </summary>
        public string? Generic { get; set; }
        /// <summary>
        /// Deleted of the Medication 
        /// </summary>
        public bool? Deleted { get; set; }
        /// <summary>
        /// MedicationType of the Medication 
        /// </summary>
        public int? MedicationType { get; set; }
        /// <summary>
        /// Foreign key referencing the Route to which the Medication belongs 
        /// </summary>
        public Guid? RouteId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Route
        /// </summary>
        [ForeignKey("RouteId")]
        public Route? Route { get; set; }
        /// <summary>
        /// Foreign key referencing the MedicationDosage to which the Medication belongs 
        /// </summary>
        public Guid? MedicationDosages { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicationDosage
        /// </summary>
        [ForeignKey("MedicationDosages")]
        public MedicationDosage? MedicationDosagesMedicationDosage { get; set; }
        /// <summary>
        /// Foreign key referencing the MedicationComposition to which the Medication belongs 
        /// </summary>
        public Guid? MedicationCompositions { get; set; }

        /// <summary>
        /// Navigation property representing the associated MedicationComposition
        /// </summary>
        [ForeignKey("MedicationCompositions")]
        public MedicationComposition? MedicationCompositionsMedicationComposition { get; set; }
        /// <summary>
        /// Foreign key referencing the DoctorFavouriteMedication to which the Medication belongs 
        /// </summary>
        public Guid? DoctorFavouriteMedication { get; set; }

        /// <summary>
        /// Navigation property representing the associated DoctorFavouriteMedication
        /// </summary>
        [ForeignKey("DoctorFavouriteMedication")]
        public DoctorFavouriteMedication? DoctorFavouriteMedicationDoctorFavouriteMedication { get; set; }
        /// <summary>
        /// Foreign key referencing the Product to which the Medication belongs 
        /// </summary>
        public Guid? Product { get; set; }

        /// <summary>
        /// Navigation property representing the associated Product
        /// </summary>
        [ForeignKey("Product")]
        public Product? ProductProduct { get; set; }
        /// <summary>
        /// Foreign key referencing the DrugListItems to which the Medication belongs 
        /// </summary>
        public Guid? DrugListItems { get; set; }

        /// <summary>
        /// Navigation property representing the associated DrugListItems
        /// </summary>
        [ForeignKey("DrugListItems")]
        public DrugListItems? DrugListItemsDrugListItems { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<Product>? Product { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<DrugListItems>? DrugListItems { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<DoctorFavouriteMedication>? DoctorFavouriteMedication { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<MedicationComposition>? MedicationComposition { get; set; }
        /// <summary>
        /// Collection navigation property representing associated 
        /// </summary>
        public ICollection<MedicationDosage>? MedicationDosage { get; set; }
    }
}