namespace AntServiceStack.FluentValidation
{
    using System;
    using System.Collections.Generic;
    using Internal;
    using Results;

    /// <summary>
    /// Defines a validator for a particualr type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<in T> : IValidator {
        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="instance">The instance to validate</param>
        /// <returns>A ValidationResult object containing any validation failures.</returns>
        ValidationResult Validate(T instance);

        /// <summary>
        /// Sets the cascade mode for all rules within this validator.
        /// </summary>
        CascadeMode CascadeMode { get; set; }
    }

    /// <summary>
    /// Defines a validator for a particular type.
    /// </summary>
    public interface IValidator : IEnumerable<IValidationRule> {
        /// <summary>
        /// Validates the specified instance
        /// </summary>
        /// <param name="instance"></param>
        /// <returns>A ValidationResult containing any validation failures</returns>
        ValidationResult Validate(object instance);


        /// <summary>
        /// Validates the specified instance.
        /// </summary>
        /// <param name="context">A ValidationContext</param>
        /// <returns>A ValidationResult object containy any validation failures.</returns>
        ValidationResult Validate(ValidationContext context);

        /// <summary>
        /// Creates a hook to access various meta data properties
        /// </summary>
        /// <returns>A IValidatorDescriptor object which contains methods to access metadata</returns>
        IValidatorDescriptor CreateDescriptor();

        /// <summary>
        /// Checks to see whether the validator can validate objects of the specified type
        /// </summary>
        bool CanValidateInstancesOfType(Type type);
    }
}