import { Injectable } from '@angular/core';
import { IRemedies } from '../../../models/modelsInterface';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root',
})
export class RemediesService {
  // remedies: IRemedies[] = [
  //   {
  //     Id: 1,
  //     Name: 'Sore Throat',
  //     Remedies: [{ Id:1,Name:'Honey'}, {Id:2, Name: 'Lemon'}],
  //     Description: 'A soothing remedy for sore throats and cough.',
  //     Benefits:
  //       'Honey is antibacterial and soothes irritation, while lemon provides vitamin C.',
  //     Preparation:
  //       'Mix 1 tablespoon of honey with the juice of half a lemon in warm water.',
  //     Usage: 'Drink 2–3 times a day.',
  //   },

  //   {
  //     Id: 2,
  //     Name: 'Digestion',
  //     Remedies: [{Id:3,Name:'Ginger Tea'}],
  //     Description:
  //       'A natural digestive aid that helps with bloating and nausea.',
  //     Benefits: 'Ginger has anti-inflammatory and stomach-settling properties.',
  //     Preparation:
  //       'Boil 1 teaspoon of grated ginger in a cup of water for 5 minutes.',
  //     Usage: 'Drink after meals.',
  //   },

  //   {
  //     Id: 3,
  //     Name: 'Inflammation',
  //     Remedies: [{Id:4,Name:'Turmeric Milk'}],
  //     Description:
  //       "Known as 'Golden Milk,' it helps reduce inflammation and boosts immunity.",
  //     Benefits:
  //       'Turmeric contains curcumin, a powerful anti-inflammatory compound.',
  //     Preparation:
  //       'Mix 1 teaspoon of turmeric powder in a cup of warm milk. Add honey for taste.',
  //     Usage: 'Drink before bedtime.',
  //   },

  //   {
  //     Id: 4,
  //     Name: 'Skin Burns',
  //     Remedies: [{Id:5,Name:'Aloe Vera'}],
  //     Description: 'A cooling gel for burns and sunburn relief.',
  //     Benefits: 'Aloe vera hydrates and promotes skin healing.',
  //     Preparation: 'Extract fresh aloe vera gel from the leaf.',
  //     Usage: 'Apply directly to the affected area 2–3 times a day.',
  //   },

  //   {
  //     Id: 5,
  //     Name: 'Headaches',
  //     Remedies: [{Id:6,Name:'Peppermint Oil'}],
  //     Description: 'A natural pain reliever for tension headaches.',
  //     Benefits:
  //       'Peppermint has menthol, which relaxes muscles and improves blood flow.',
  //     Preparation:
  //       'Dilute a few drops of peppermint oil with a carrier oil (like coconut oil).',
  //     Usage: 'Massage onto temples and the back of the neck',
  //   },
  // ];

  private apiUrl = `https://localhost:7218/api`;

  constructor(private http: HttpClient) {}

  getRemedies() {
    return this.http.get<IRemedies[]>(`${this.apiUrl}/Remedies`);
  }

  getRemediesByName(name: string): Observable<IRemedies[]> {
    let params = new HttpParams().set('DiseaseName', name);

    return this.http.get<IRemedies[]>(`${this.apiUrl}/remedies/search`, {
      params,
    });
  }
}
