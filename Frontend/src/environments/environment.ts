// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  // endpoint: 'http://localhost:3000/customers'
  globalEndpoint: 'https://localhost:5001/api/',
  endpoint: 'https://localhost:5001/api/patient',
  endpointUpload: 'https://localhost:5001/api/upload',
  useAuth: false,
  // api: {
  //   host: 'https://localhost',
  //   port: 5001,
  //   suffix: 'api'
  // }
  api: {
    host: 'http://reflexartigleicht.azurewebsites.net/',
    port: 8080,
    suffix: 'api'
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
import 'zone.js/dist/zone-error';  // Included with Angular CLI.
