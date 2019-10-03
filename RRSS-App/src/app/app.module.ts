import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { MapComponent } from "./map/map.component";
import { NgxMapboxGLModule } from "ngx-mapbox-gl";
import { environment } from "src/environments/environment";

@NgModule({
  declarations: [AppComponent, MapComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxMapboxGLModule.withConfig({
      accessToken: environment.mapbox.accessToken,
      geocoderAccessToken: environment.mapbox.accessToken,
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
