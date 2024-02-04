import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import styles from "./SideBar.module.css";
import MapPinIcon from "./MapPinIcon";
import Map from "./Map";

const SideBar = () => {
  const [selectedCoordinate, setSelectedCoordinate] = useState(null);

  const handleMarkerClick = (point) => {
    setSelectedCoordinate(point);
  };

  return (
    <>
      <div className={styles.containerSideBar}>
        {/* Боковое меню */}
        <div className={styles.sidebaropened}>
          {selectedCoordinate ? (
            <>
              <b className={styles.b}>Сведения о повреждении</b>

              {/* Фото повреждения */}
              <img className={styles.icon} alt="" src="/@2x.png" />

              {/* Координаты */}
              <div className={styles.mapPinIcon}><MapPinIcon/></div>
              <div className={styles.div}>
                <div className={styles.div1}>{selectedCoordinate.coordinates[0]}°</div>
                <div className={styles.div2}>{selectedCoordinate.coordinates[1]}°</div>
              </div>

              {/* Полная информация */}
              <div className={styles.div7}>Текущее состояние</div>
              <div className={styles.example4}>Example</div>
              <div className={styles.div6}>Характер повреждения</div>
              <div className={styles.example3}>Example</div>
              <div className={styles.div8}>Дата обследования</div>
              <div className={styles.example5}>Example</div>
              <div className={styles.line1}></div>
              <div className={styles.div5}>Дрон</div>
              <div className={styles.example2}>Example</div>
              <div className={styles.div4}>Полезная нагрузка</div>
              <div className={styles.example1}>Example</div>
              <div className={styles.line2}></div>
              <div className={styles.div3}>Бригада</div>
              <div className={styles.example}>Example</div>
              <div className={styles.line3}></div>
            </>
          ) : (
            <p className={styles.b}>Выберите точку</p>
          )}
        </div>

        {/* Карта */}
        <div className={styles.map}>
          <Map onMarkerClick={handleMarkerClick} />
        </div>
      </div>
    </>
  );
};

export default SideBar;

