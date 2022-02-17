namespace BattleCards.ViewModels.Cards
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants.Card;

    public class CreateCardViewModel
    {
        [StringLength(CardNameMaxLength, MinimumLength = CardNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Name { get; set; }

        [StringLength(ImageUrlMaxLenght, MinimumLength = 1, ErrorMessage = "{0} is required , and sould not be longet than {2}")]
        public string Image { get; set; }

        public string Keyword { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public int Attack { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public int Health { get; set; }

        [StringLength(DescriptionMaxLenght, MinimumLength = 0, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Description { get; set; }
    }
}
