module.exports = async function (context, req) {
	context.log('JavaScript HTTP trigger function processed a request.');

	// const body = JSON.parse( JSON.stringify( req.body ) );

	// console.log('************************************');
	// console.log( req.body.name );
	// console.log('************************************');

	console.log('*** Testing updating Azure Function from package');

	if (req.query.name || (req.body && req.body.name)) {
		context.res = {
			// status: 200, /* Defaults to 200 */
			body: "Hello " + (req.query.name || req.body.name)
		};
	} else {
		context.res = {
			status: 400,
			body: `Please pass a name on the query string or in the request body`
		};
	};

	context.done();
};