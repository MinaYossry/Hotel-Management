#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Reservation__DbContext.Models;

[Table("reservation")]
public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [Column("birth_day")]
    [StringLength(50)]
    public string BirthDay { get; set; }

    [Required]
    [Column("gender")]
    [StringLength(50)]
    public string Gender { get; set; }

    [Required]
    [Column("phone_number")]
    [StringLength(50)]
    public string PhoneNumber { get; set; }

    [Required]
    [Column("email_address")]
    public string EmailAddress { get; set; }

    [Column("number_guest")]
    public int NumberGuest { get; set; }

    [Required]
    [Column("street_address")]
    public string StreetAddress { get; set; }

    [Required]
    [Column("apt_suite")]
    [StringLength(50)]
    public string AptSuite { get; set; }

    [Required]
    [Column("city")]
    public string City { get; set; }

    [Required]
    [Column("state")]
    [StringLength(50)]
    public string State { get; set; }

    [Required]
    [Column("zip_code")]
    [StringLength(10)]
    public string ZipCode { get; set; }

    [Required]
    [Column("room_type")]
    [StringLength(10)]
    public string RoomType { get; set; }

    [Required]
    [Column("room_floor")]
    [StringLength(10)]
    public string RoomFloor { get; set; }

    [Required]
    [Column("room_number")]
    [StringLength(10)]
    public string RoomNumber { get; set; }

    [Column("total_bill")]
    public double TotalBill { get; set; }

    [Required]
    [Column("payment_type")]
    [StringLength(10)]
    public string PaymentType { get; set; }

    [Required]
    [Column("card_type")]
    [StringLength(10)]
    public string CardType { get; set; }

    [Required]
    [Column("card_number")]
    [StringLength(50)]
    public string CardNumber { get; set; }

    [Required]
    [Column("card_exp")]
    [StringLength(50)]
    public string CardExp { get; set; }

    [Required]
    [Column("card_cvc")]
    [StringLength(10)]
    public string CardCvc { get; set; }

    [Column("arrival_time", TypeName = "date")]
    public DateTime ArrivalTime { get; set; }

    [Column("leaving_time", TypeName = "date")]
    public DateTime LeavingTime { get; set; }

    [Column("check_in")]
    public bool CheckIn { get; set; }

    [Column("break_fast")]
    public int BreakFast { get; set; }

    [Column("lunch")]
    public int Lunch { get; set; }

    [Column("dinner")]
    public int Dinner { get; set; }

    [Column("cleaning")]
    public bool Cleaning { get; set; }

    [Column("towel")]
    public bool Towel { get; set; }

    [Column("s_surprise")]
    public bool SSurprise { get; set; }

    [Column("supply_status")]
    public bool SupplyStatus { get; set; }

    [Column("food_bill")]
    public int FoodBill { get; set; }
}