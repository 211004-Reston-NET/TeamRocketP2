import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { News } from '../models/news';
import { Restaurant } from '../models/restaurant';
import { Review } from '../models/review';

@Injectable({
  providedIn: 'root'
})
export class RevAPIService {

  private endpoint:string = "https://211004-rr-web-app.azurewebsites.net/api";

private endpoint2:string='https://google-translate1.p.rapidapi.com/language/translate/v2?key=86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55';
private endpoint3:string="https://google-translate20.p.rapidapi.com/translate?"
private endpoint4:string="https://community-open-weather-map.p.rapidapi.com/weather?";
private endpoint4b:string="https://community-open-weather-map.p.rapidapi.com/forecast?";
private endpoint5:string="https://google-news.p.rapidapi.com/v1/geo_headlines?lang=en&geo=Japan";
private endpoint5b:string="https://google-news1.p.rapidapi.com/top-headlines?country=Japan&lang=ja&limit=50";

  constructor(private http:HttpClient) {
   }

  //This will give us a list of restaurant from RevWebAPI
  //Will return an observable that is a list of restaurant
  getAllRestaurant() :Observable<Restaurant[]>
  {
    //httpclient get() method will do a get request to the api
    //Make sure you got the endpoint right
    return this.http.get<Restaurant[]>(this.endpoint + "/Restaurant/All");
  }

  //This will give me a list of reviews based on the restId
  getReviewByRestId(p_id:number) : Observable<any>
  {
    return this.http.get<any>(this.endpoint + "/Review/" + p_id);
  }

  translate(p_text:string): Observable<any>
  {
    const headers= new HttpHeaders()


    .set('x-rapidapi-key', '86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55')
    .set('x-rapidapi-host', 'google-translate20.p.rapidapi.com')
    //.set('content-type', 'application/x-www-form-urlencoded');

    return this.http.get<any>(this.endpoint3+"text="+p_text+"&tl=en",{ 'headers': headers, withCredentials: true });



    // const headers= new HttpHeaders()

    // //.append('content-type','application/x-www-form-urlencoded')
    // //.set( 'content-type', 'application/json')
    // .set('x-rapidapi-key', '86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55')
    // .set('x-rapidapi-host', 'google-translate1.p.rapidapi.com')
    // //.set('content-type', 'application/x-www-form-urlencoded');
    // console.log(headers);
    // const body={ "q": p_text,
    //             "target":'en' };
    //             const body2=JSON.stringify(body);
    // console.log(body2);
    // return this.http.post<any>(this.endpoint2+"q=hola&target=en",null,{ 'headers': headers, withCredentials: true });

  }

  GetCurrentWeather(p_text:string): Observable<any>
  {

    const headers= new HttpHeaders()
    // .set('content-type', 'application/x-www-form-urlencoded')
    .set('x-rapidapi-key', '86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55')
    .set('x-rapidapi-host', 'community-open-weather-map.p.rapidapi.com');
    console.log(headers);
    return this.http.get<any>(this.endpoint4+"q="+p_text+"&units=imperial",{ 'headers': headers });

  }
 GeoHeadlines():Observable<any>
  {
    const headers= new HttpHeaders()
    // .set('content-type', 'application/x-www-form-urlencoded')
    .set('x-rapidapi-key', '86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55')
    .set('x-rapidapi-host', 'google-news.p.rapidapi.com');
    console.log(headers);
    return this.http.get<any>(this.endpoint5,{ 'headers': headers });

  }

  FiveDayForecast(p_text:string):Observable<any>
  {
    const headers= new HttpHeaders()
    // .set('content-type', 'application/x-www-form-urlencoded')
    .set('x-rapidapi-key', '86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55')
    .set('x-rapidapi-host', 'community-open-weather-map.p.rapidapi.com');
    console.log(headers);
    return this.http.get<any>(this.endpoint4b+"q="+p_text+"%2Cjp&units=imperial",{ 'headers': headers });
  }

  JapaneseHeadlines():Observable<any>
  {
    const headers= new HttpHeaders()
    // .set('content-type', 'application/x-www-form-urlencoded')
    .set('x-rapidapi-key', '86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55')
    .set('x-rapidapi-host', 'google-news1.p.rapidapi.com');
    console.log(headers);
    return this.http.get<any>(this.endpoint5b,{ 'headers': headers });

  }



}
