import { Component, OnInit } from '@angular/core';
import { ImageDTO } from '../Api/models';
import { ImageService } from '../Api/services';
import { MatTableDataSource } from '@angular/material';
import { AuthService } from '../auth.service';
import { saveAs } from 'file-saver';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})


export class ImageComponent implements OnInit {
  displayedColumns: string[] = ['name', 'filePath', 'action'];
  dataSource: MatTableDataSource<ImageDTO> = new MatTableDataSource<ImageDTO>();

  constructor(private imageService: ImageService,
    private authService: AuthService) { }

  ngOnInit() {
    this.imageService.Get().subscribe(images => {
      this.dataSource.data = images;
    })
  }

  isAuthenticated(): boolean {
    return this.authService.isAuthenticated();
  }

  DeleteAllImages() {
    this.imageService.DeleteAll().subscribe(() => {
      this.dataSource.data = [];
    })
  }

  DownloadImage(image: ImageDTO) {
    this.imageService.DownloadFile(image.name).subscribe(res => {
      saveAs(res); 
    });
  }

  handleFileInput(files: FileList) {
    this.imageService.Post(files[0]).subscribe((image) => {
      let data = this.dataSource.data;
      data.push(image);
      this.dataSource.data = data;
    })
  }
  DeleteImage(image: ImageDTO) {
    this.imageService.Delete(image).subscribe(() => {
      let data = this.dataSource.data;
      const index: number = data.indexOf(image);
      if (index !== -1) {
        data.splice(index, 1);
        this.dataSource.data = data;
      }  
    });
  }




}
