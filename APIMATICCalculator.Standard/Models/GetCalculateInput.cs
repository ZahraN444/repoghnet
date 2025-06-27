// <copyright file="GetCalculateInput.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMATICCalculator.Standard;
using APIMATICCalculator.Standard.Utilities;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace APIMATICCalculator.Standard.Models
{
    /// <summary>
    /// GetCalculateInput.
    /// </summary>
    public class GetCalculateInput : BaseModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCalculateInput"/> class.
        /// </summary>
        public GetCalculateInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCalculateInput"/> class.
        /// </summary>
        /// <param name="operation">operation.</param>
        /// <param name="x">x.</param>
        /// <param name="y">y.</param>
        public GetCalculateInput(
            Models.OperationType operation,
            double x,
            double y)
        {
            this.Operation = operation;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// The operator to apply on the variables
        /// </summary>
        [JsonProperty("operation")]
        public Models.OperationType Operation { get; set; }

        /// <summary>
        /// The LHS value
        /// </summary>
        [JsonProperty("x")]
        public double X { get; set; }

        /// <summary>
        /// The RHS value
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GetCalculateInput : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is GetCalculateInput other &&
                (this.Operation.Equals(other.Operation)) &&
                (this.X.Equals(other.X)) &&
                (this.Y.Equals(other.Y)) &&
                base.Equals(obj);
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected new void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Operation = {this.Operation}");
            toStringOutput.Add($"X = {this.X}");
            toStringOutput.Add($"Y = {this.Y}");

            base.ToString(toStringOutput);
        }
    }
}