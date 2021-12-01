import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ForumPosts } from '../models/ForumPosts';
import { Forums } from '../models/Forums';
import { News } from '../models/news';
import { Replies } from '../models/Replies';
import { Restaurant } from '../models/restaurant';
import { Review } from '../models/review';
import { Users } from '../models/Users';

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

  Users():Observable<Users[]>
  {
    return this.http.get<Users[]>("https://teamrocketapi.azurewebsites.net/api/user/all");
  }
  Forums():Observable<Forums[]>
  {
    return this.http.get<Forums[]>("https://teamrocketapi.azurewebsites.net/api/forum/all");
  }
  Posts():Observable<ForumPosts[]>
  {
    return this.http.get<ForumPosts[]>("https://teamrocketapi.azurewebsites.net//api/Post/ByForum1");
  }
  PostsbyId(p_text:any):Observable<ForumPosts[]>
  {
    return this.http.get<ForumPosts[]>("https://teamrocketapi.azurewebsites.net//api/Post/ByForum"+p_text);
  }

  Reply():Observable<Replies[]>
  {
    return this.http.get<Replies[]>("https://teamrocketapi.azurewebsites.net//api/Reply/ByPost1");
  }
 ReplybyId(p_text:any):Observable<Replies[]>
  {
    console.log(p_text);
    return this.http.get<Replies[]>("https://teamrocketapi.azurewebsites.net//api/Reply/ByPost"+p_text);
  }


   AddUser(p_item:Users):Observable<Users>
   {


   
    return this.http.post<Users>("https://teamrocketapi.azurewebsites.net/api/user/Add",p_item);
  }


  // const data = null;

  // const xhr = new XMLHttpRequest();
  // xhr.withCredentials = true;
  
  // xhr.addEventListener("readystatechange", function () {
  //   if (this.readyState === this.DONE) {
  //     console.log(this.responseText);
  //   }
  // });
  
  // xhr.open("GET", "https://navitime-maps.p.rapidapi.com/map_image?width=500&center=35.681236%2C139.767125&zoom=15&height=500&datum=wgs84&coord_unit=degree");
  // xhr.setRequestHeader("x-rapidapi-key", "86cdbd2072msh31d13534aa18519p1285cfjsnf663f86b2e55");
  // xhr.setRequestHeader("x-rapidapi-host", "navitime-maps.p.rapidapi.com");
  
  // xhr.send(data);

}
