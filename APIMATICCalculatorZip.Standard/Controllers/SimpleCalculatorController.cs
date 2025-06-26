// <copyright file="SimpleCalculatorController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using APIMATICCalculatorZip.Standard;
using APIMATICCalculatorZip.Standard.Http.Client;
using APIMATICCalculatorZip.Standard.Utilities;
using Newtonsoft.Json.Converters;
using System.Net.Http;

namespace APIMATICCalculatorZip.Standard.Controllers
{
    /// <summary>
    /// SimpleCalculatorController.
    /// </summary>
    public class SimpleCalculatorController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleCalculatorController"/> class.
        /// </summary>
        internal SimpleCalculatorController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="operation">Required parameter: The operator to apply on the variables.</param>
        /// <param name="x">Required parameter: The LHS value.</param>
        /// <param name="y">Required parameter: The RHS value.</param>
        /// <returns>Returns the double response from the API call.</returns>
        public double Calculate(
                Models.OperationTypeEnum operation,
                double x,
                double y)
            => CoreHelper.RunTask(CalculateAsync(operation, x, y));

        /// <summary>
        /// Calculates the expression using the specified operation.
        /// </summary>
        /// <param name="operation">Required parameter: The operator to apply on the variables.</param>
        /// <param name="x">Required parameter: The LHS value.</param>
        /// <param name="y">Required parameter: The RHS value.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the double response from the API call.</returns>
        public async Task<double> CalculateAsync(
                Models.OperationTypeEnum operation,
                double x,
                double y,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<double>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/{operation}")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("operation", ApiHelper.JsonSerialize(operation).Trim('\"')))
                      .Query(_query => _query.Setup("x", x))
                      .Query(_query => _query.Setup("y", y))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => double.Parse(_response)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}