import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { MaterialModule } from '../../../material/material.module';
import { MatTableDataSource } from '@angular/material/table';
import { IPet } from '../../../Interfaces/IPet.Interface';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { RouterLink } from '@angular/router';
import { PetsService } from '../pets.service';

@Component({
    selector: 'app-pets',
    imports: [MaterialModule, RouterLink],
    templateUrl: './pets.component.html',
    styleUrl: './pets.component.scss'
})
export class PetsComponent implements AfterViewInit, OnInit {
  pets: IPet[] = [];
  #petService: PetsService = inject(PetsService)

  displayedColumns: string[] = [
    'id',
    'cachorroNome',
    'donoNome',
    'cachorroSexo',
    'cachorroRaca',
    'opcoes'
  ];
  dataSource!: MatTableDataSource<IPet>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;


  ngOnInit() {
    this.dataSource = new MatTableDataSource();
    this.#petService.getPets().subscribe()
    this.#petService.Pet$.subscribe((pets) =>{
      console.log(pets)
      this.dataSource.data = pets;
    })
    
  }


 

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  
}

