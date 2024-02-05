import React, { useEffect, useState } from 'react';
import 'leaflet/dist/leaflet.css';
import '2gis-maps';

const Map = ({ onMarkerClick }) => {
  const [pointss, setPoints] = useState(null);
  useEffect(() => {
    async function fetchData() {
      try {
        const result = await fetch("https://localhost:7001/Coordinates", {
          method: "GET",
        });

        const data = await result.json();
        setPoints(data);
      } catch (error) {
        console.error(error);
      }
    }

    fetchData();
  }, []);

  useEffect(() => {
    var map = DG.map('map', {
      center: [54.912749, 52.316317],
      zoom: 13
    });

    if (pointss) {
      pointss.forEach((point) => {
        const marker = DG.marker(point.coordinates);
        marker.on('click', () => {
          onMarkerClick(point);
        });
        marker.addTo(map);
        ///const pointsData = [
          //       { coordinates: [54.919, 52.319], info: 'Информация о точке 1' }
          //     ];
          //
          //
          //     // // Отображение зоны на карте
          //     // const zoneData = {
          //     //     name: 'Example Zone',
          //     //     coordinates: [
          //     //       [54.912, 52.32],
          //     //       [54.924, 52.32],
          //     //       [54.924, 52.38],
          //     //       [54.912, 52.38]
          //     //     ]
          //     //   };
          //
          //     // const polygon = DG.polygon(zoneData.coordinates, { color: 'white' }).addTo(map);
          //
          //
          //     pointsData.forEach((point) => {
          //       const marker = DG.marker(point.coordinates);
          //       marker.on('click', () => {
          //         onMarkerClick(point);
      });
    }

    return () => {
      map.remove();
    };
  }, [pointss, onMarkerClick]);

  return <div id="map" style={{ height: '100vh', width: '100vw' }}></div>;
};

export default Map;
