/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpResponse, HttpHeaders } from '@angular/common/http';
import { BaseService as __BaseService } from '../base-service';
import { ApiConfiguration as __Configuration } from '../api-configuration';
import { StrictHttpResponse as __StrictHttpResponse } from '../strict-http-response';
import { Observable as __Observable } from 'rxjs';
import { map as __map, filter as __filter } from 'rxjs/operators';

import { ImageDTO } from '../models/image-dto';
@Injectable({
  providedIn: 'root',
})
class ImageService extends __BaseService {
  static readonly GetPath = '/api/Image/GetAllImages';
  static readonly DownloadFilePath = '/api/Image/DownloadFile/{fileName}';
  static readonly PostPath = '/api/Image/UploadImage';
  static readonly DeletePath = '/api/Image/Delete';
  static readonly DeleteAllPath = '/api/Image';

  constructor(
    config: __Configuration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * @return Success
   */
  GetResponse(): __Observable<__StrictHttpResponse<Array<ImageDTO>>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Image/GetAllImages`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<Array<ImageDTO>>;
      })
    );
  }
  /**
   * @return Success
   */
  Get(): __Observable<Array<ImageDTO>> {
    return this.GetResponse().pipe(
      __map(_r => _r.body as Array<ImageDTO>)
    );
  }

  /**
   * @param fileName undefined
   */
  DownloadFileResponse(fileName: string): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;

    let req = new HttpRequest<any>(
      'GET',
      this.rootUrl + `/api/Image/DownloadFile/${fileName}`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param fileName undefined
   */
  DownloadFile(fileName: string): __Observable<null> {
    return this.DownloadFileResponse(fileName).pipe(
      __map(_r => _r.body as null)
    );
  }

  /**
   * @param Image undefined
   * @return Success
   */
  PostResponse(Image?: Blob): __Observable<__StrictHttpResponse<ImageDTO>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let __formData = new FormData();
    __body = __formData;
    if (Image != null) { __formData.append('Image', Image as string | Blob);}
    let req = new HttpRequest<any>(
      'POST',
      this.rootUrl + `/api/Image/UploadImage`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<ImageDTO>;
      })
    );
  }
  /**
   * @param Image undefined
   * @return Success
   */
  Post(Image?: Blob): __Observable<ImageDTO> {
    return this.PostResponse(Image).pipe(
      __map(_r => _r.body as ImageDTO)
    );
  }

  /**
   * @param imageDTO undefined
   */
  DeleteResponse(imageDTO?: ImageDTO): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    __body = imageDTO;
    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Image/Delete`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }
  /**
   * @param imageDTO undefined
   */
  Delete(imageDTO?: ImageDTO): __Observable<null> {
    return this.DeleteResponse(imageDTO).pipe(
      __map(_r => _r.body as null)
    );
  }
  DeleteAllResponse(): __Observable<__StrictHttpResponse<null>> {
    let __params = this.newParams();
    let __headers = new HttpHeaders();
    let __body: any = null;
    let req = new HttpRequest<any>(
      'DELETE',
      this.rootUrl + `/api/Image`,
      __body,
      {
        headers: __headers,
        params: __params,
        responseType: 'json'
      });

    return this.http.request<any>(req).pipe(
      __filter(_r => _r instanceof HttpResponse),
      __map((_r) => {
        return _r as __StrictHttpResponse<null>;
      })
    );
  }  DeleteAll(): __Observable<null> {
    return this.DeleteAllResponse().pipe(
      __map(_r => _r.body as null)
    );
  }
}

module ImageService {
}

export { ImageService }
